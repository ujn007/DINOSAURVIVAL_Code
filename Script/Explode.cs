using DG.Tweening;
using RayFire;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Explode : MonoBehaviour
{
    [SerializeField] Image panel;
    RayfireBomb bomb;

    private void Awake()
    {
        bomb = GetComponent<RayfireBomb>();
    }

    public void Explosion()
    {
        bomb.Explode(0);
    }
}
