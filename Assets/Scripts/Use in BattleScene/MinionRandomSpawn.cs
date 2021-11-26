using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionRandomSpawn : MonoBehaviour
{
    ObjectGenerator og;
    public BossCombat bc;

    public GameObject[] minions = new GameObject[2];

    
    private void Start()
    {
        og = GameObject.FindObjectOfType<ObjectGenerator>().GetComponent<ObjectGenerator>();
       
        StartCoroutine(SpawnMinion());
    }
    private void Update()
    {
        if(bc.BossKill > 0)
        {
            StopCoroutine(SpawnMinion());
        }
    }
    IEnumerator SpawnMinion()
    {

        int rand = (int)Random.Range(2, 4);
        while (true)
        {
            int index = (int)Time.time % 2;

            yield return new WaitForSeconds(rand);

            SpawnEnemy(index);

            rand = (int)Random.Range(8, 10);
        }
    }
    void SpawnEnemy(int i)
    {
        Instantiate(minions[i]);
    }
}
