using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    [SerializeField] Image rayCompleteScan;
    [SerializeField] Image houseKidOnMap;

    private void OnEnable()
    {
        UIManager_Scene1_3.completeScanning += CompleteScanning;
    }

    private void OnDestroy()
    {
        UIManager_Scene1_3.completeScanning -= CompleteScanning;
    }

    public void CompleteScanning()
    {
        rayCompleteScan.gameObject.SetActive(true);
        houseKidOnMap.gameObject.SetActive(true);
    }
}
