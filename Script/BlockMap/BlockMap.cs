using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockMap : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waringText;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            waringText.DOFade(1, 3);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            waringText.DOFade(0, 3);
        }
    }
}
