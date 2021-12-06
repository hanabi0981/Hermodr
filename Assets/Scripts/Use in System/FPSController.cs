using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    private float deltaTime = 0f;

    public bool _isShow = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (Input.GetKeyDown(KeyCode.F1))
        {
            _isShow = !_isShow;
        }
    }

    private void OnGUI()
    {
        if (_isShow)
        {
            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(30, 30, Screen.width, Screen.height);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = 60;

            float ms = deltaTime * 1000f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.} FPS ({1:0:0} ms)", fps, ms);

            GUI.Label(rect, text, style);
        }
    }
}
