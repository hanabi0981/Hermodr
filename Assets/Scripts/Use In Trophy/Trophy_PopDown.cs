using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy_PopDown : MonoBehaviour
{
    public GameObject trophyGroup;

    public void Tropy_PopDown()
    {
        trophyGroup.SetActive(false);
    }
}
