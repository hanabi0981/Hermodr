using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Inst { get; private set; }
    private void Awake() => Inst = this;

    [SerializeField] GameObject entityPrefab;
    [SerializeField] List<Entity> myEntities;
    [SerializeField] List<Entity> otherEntities;
}
