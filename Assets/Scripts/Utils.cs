using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PRS
{
    public Vector2 pos;
    public Quaternion rot;
    public Vector2 scale;

    public PRS(Vector2 pos, Quaternion rot, Vector2 scale)
    {
        this.pos = pos;
        this.rot = rot;
        this.scale = scale;
    }
}
public class Utils : MonoBehaviour
{
    public static Quaternion QI => Quaternion.identity;
}
