using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBuildVersion : MonoBehaviour
{
    [SerializeField]
    private Text version;
    // Start is called before the first frame update
    void Start()
    {
        version.text = "V " + Application.version;
    }
}
