using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelectCriminal : MonoBehaviour
{
    [SerializeField] public int id_Criminal;
    [SerializeField] public Sprite spriteFingerPrints;
    public bool canClick = true;
    private void OnMouseDown()
    {
        if (canClick) Scene8_5Manager.Instance.ClickOnCriminal(id_Criminal);

    }
}
