using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RayFire;
using UnityEngine.SceneManagement;

public class meteor : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    [SerializeField] Transform defaultPos;
    Transform modelTrm;
    Transform modelRootTrm;
    Transform trailTrm;
    bool isMoving;

    private void Awake()
    {
        modelTrm = transform.GetChild(0).transform;
        if (SceneManager.GetActiveScene().name == "2.FailScene")
            modelRootTrm = GetComponentInChildren<RayfireBomb>().transform; 
        trailTrm = transform.GetChild(1).transform;
    }

    private void Start()
    {
        transform.DOMove(defaultPos.position, speed).SetEase(Ease.Linear);
    }

    private void Update()
    {
        modelTrm.Rotate(Vector3.right * rotationSpeed);

        if (modelRootTrm != null)
            modelRootTrm.Rotate(Vector3.right * rotationSpeed);

        trailTrm.localPosition = Vector3.zero;
    }

    public void Moving(int _speed)
    {
        transform.DOMove(defaultPos.position, _speed).SetEase(Ease.Linear);
    }
}
