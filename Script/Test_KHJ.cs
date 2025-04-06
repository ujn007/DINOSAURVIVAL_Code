using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PoolManager;

public class Test_KHJ : MonoBehaviour
{
    [Header("���ʹ� ������ ��⳪���� ��.\n �ϰ� �˾Ƽ� ����")]
    [SerializeField] GameObject dino;
    [SerializeField] int spawnCount;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < spawnCount; ++i) 
                PoolManagerq.SpawnFromPool("Meat", dino.transform.position, Quaternion.identity);
            Destroy(dino);//������� ȿ�� �ʿ���

            GameObject[] gm = GameObject.FindGameObjectsWithTag("Meat");
            foreach(var dd in gm)
            {
                RetuenPool pool = dd.GetComponent<RetuenPool>();
                pool.Spawn();
            }
        }
    }

    
}
