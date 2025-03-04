using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;
using UnityEngine.UI;

public class DivergeMeteor : MonoBehaviour
{
    RayfireShatter shatter;
    [SerializeField] Image panel;

    private RayfireBomb bomb;

    private void Awake()
    {
        shatter = GetComponentInChildren<RayfireShatter>();
        bomb = GetComponentInChildren<RayfireBomb>();
    }

    private void Update()
    {
        ScalePreview(shatter);
    }

    public void Diverge()
    {
        Sequence sq = DOTween.Sequence();
        sq.AppendInterval(1);
        sq.Append(DOTween.To(() => shatter.previewScale, x => shatter.previewScale = x, 0.07f, 0.3f));
        sq.AppendInterval(1);
        sq.Append(DOTween.To(() => shatter.previewScale, x => shatter.previewScale = x, 0.12f, 0.3f));
        sq.AppendInterval(0.3f);
        sq.Append(DOTween.To(() => shatter.previewScale, x => shatter.previewScale = x, 0.15f, 0.3f));
    }
     void ScalePreview(RayfireShatter scr)
    {
        if (scr.fragmentsLast.Count > 0 && scr.previewScale > 0f)
        {
            // Do not scale
            if (scr.skinnedMeshRend != null)
                scr.skinnedMeshRend.enabled = false;
            if (scr.meshRenderer != null)
                scr.meshRenderer.enabled = false;

            foreach (GameObject fragment in scr.fragmentsLast)
                if (fragment != null)
                    fragment.transform.localScale = Vector3.one * scr.PreviewScale();
            scr.resetState = true;
        }

        if (scr.previewScale == 0f)
            scr.ResetScale(0f);
    }

    public void Explosion()
    {
        bomb.Explode(0);
    }
}
