using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalController8_5 : MonoBehaviour
{
    [SerializeField] public List<SkeletonAnimation> listCriminalSkele;
    void OnEnable()
    {
        Scene8_5Manager.Instance.listCriminalSkele = listCriminalSkele;
    }

   
}
