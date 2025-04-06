using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDinoMeat : MonoBehaviour
{
    [SerializeField] GameObject dino;
    [SerializeField] int spawnCount;

    private void Awake()
    {
        dino = gameObject;
    }

    private void DropMeat()
    {
        for (int i = 0; i < spawnCount; ++i)
            PoolManagerq.SpawnFromPool("Meat", dino.transform.position, Quaternion.identity);
        Destroy(dino);//사라지는 효과 필요함

        GameObject[] gm = GameObject.FindGameObjectsWithTag("Meat");
        foreach (var dd in gm)
        {
            RetuenPool pool = dd.GetComponent<RetuenPool>();
            pool.Spawn();
        }
    }
}
