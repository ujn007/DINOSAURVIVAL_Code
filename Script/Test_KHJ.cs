using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PoolManager;

public class Test_KHJ : MonoBehaviour
{
    [Header("에너미 죽으면 고기나오게 함.\n 니가 알아서 연결")]
    [SerializeField] GameObject dino;
    [SerializeField] int spawnCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < spawnCount; ++i) 
                PoolManagerq.SpawnFromPool("Meat", dino.transform.position, Quaternion.identity);
            Destroy(dino);//사라지는 효과 필요함

            GameObject[] gm = GameObject.FindGameObjectsWithTag("Meat");
            foreach(var dd in gm)
            {
                RetuenPool pool = dd.GetComponent<RetuenPool>();
                pool.Spawn();
            }
        }
    }

    
}
