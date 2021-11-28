using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailController : MonoBehaviour
{
    public GameObject window;
    [SerializeField]
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "V 1.0 \n 헤르모드 : 전쟁의 투혼(Beta) \n _토벌 컨텐츠 업데이트 \n _아이템 밸런스 조정 \n _신성 밸런스 조정";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopUp()
    {
        window.SetActive(true);
    }
}
