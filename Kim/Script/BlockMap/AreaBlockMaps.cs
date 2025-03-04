using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AreaBlockMaps : MonoBehaviour
{
    [SerializeField] Image fogPanel;
    Vector3 waringScalePos;
    Vector3 blockScalePos;
    float intervalDis;
    private Transform player;
    private void Awake()
    {
        waringScalePos = transform.GetChild(0).GetComponent<Transform>().localScale;
        blockScalePos = transform.GetChild(1).GetComponent<Transform>().localScale;

        intervalDis = Mathf.Abs(waringScalePos.x - blockScalePos.x) / 2;
    }
    private IEnumerator Start()
    {
        yield return YieldCache.WaitUntil(() => (SceneManagement.Instance.CurrentScene as GameScene)?.Player != null);
        player = (SceneManagement.Instance.CurrentScene as GameScene)?.Player.transform;
    }

    private void Update()
    {
        if (player == null)
            return;
        float areaDis = Vector3.Distance(transform.position, player.position);

        if (areaDis >= waringScalePos.x / 2)
        {
            float waringAreaOutPlayerPos = areaDis - waringScalePos.x / 2;
            float interval = Mathf.Clamp(waringAreaOutPlayerPos, 0, intervalDis);

            fogPanel.color = new Color(1, 1, 1, (interval / intervalDis) * 0.7f);
        }
    }
}
