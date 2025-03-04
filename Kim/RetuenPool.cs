using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetuenPool : MonoBehaviour
{
    [SerializeField] float forceValue;
    [SerializeField] float forceDir;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Spawn()
    {
        float randX = Random.Range(-forceDir, forceDir);
        float randZ = Random.Range(-forceDir, forceDir);
        rigid.AddForce(new Vector3(randX, forceValue, randZ), ForceMode.Impulse);
        //rigid.AddExplosionForce(forceValue, transform.position, forceDir);
    }

    private void OnDisable()
    {
        PoolManagerq.ReturnToPool(this.gameObject);
        CancelInvoke();
    }


}
