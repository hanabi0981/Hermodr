using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool _isDragActive = false;
    private Vector3 _originPosition;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    [SerializeField] GameObject unitPrefab;
    [SerializeField] Transform unitSpawnPosition;

    private bool totem;

    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }    

    // Update is called once per frame
    void Update()
    {
        if(_isDragActive)
        {
            if(Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
             Drop();
             return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        _isDragActive = true;
        
        _originPosition = _worldPosition - _lastDragged.transform.position;

    }

    void Drag()
    {
        _lastDragged.transform.position = _worldPosition - _originPosition;
    }

    void Drop()
    {
        _isDragActive = false;
//        Debug.Log(GetComponent<CardActivate>().isActivate);
        if (_lastDragged.gameObject.GetComponent<CardActivate>().isActivate)
        {
            Instantiate(unitPrefab, unitSpawnPosition.position, Utils.QI);
            Destroy(_lastDragged.gameObject);
            GetComponent<CardActivate>().isActivate = false;
            Debug.Log("active");
        }    
    }    
}
