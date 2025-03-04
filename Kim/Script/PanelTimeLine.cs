using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTimeLine : MonoBehaviour
{
    Image im;

    private void Awake()
    {
        im = GetComponent<Image>();
    }

    private void Start()
    {
       
    }

    public void Fade(int time)
    {
        im.DOFade(1, time);
    }
}
