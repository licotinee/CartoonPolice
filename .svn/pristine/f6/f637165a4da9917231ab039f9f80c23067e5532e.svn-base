using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Scene1_3 : MonoBehaviour
{
    public static UIManager_Scene1_3 ins;
    [SerializeField] Image table;
    [SerializeField] Image scanningGamePlayPanel;
    public delegate void CompleteScanning();
    public static event CompleteScanning completeScanning;
    private void Awake()
    {
        ins = this;
    }

    private void OnEnable()
    {
        LostKid.kidPushHandOnButton += ActiveScanningGamePlayPanel;
    }

    private void OnDestroy()
    {
        LostKid.kidPushHandOnButton -= ActiveScanningGamePlayPanel;
    }

    public void ActiveFingerScaning()
    {
        table.GetComponent<Table_Scene1_3>().EnableScaning();
    }

    public void ActiveScanningGamePlayPanel()
    {
        scanningGamePlayPanel.gameObject.SetActive(true);
    }

    public void CompleteScanningGamePlayPanel()
    {
        scanningGamePlayPanel.gameObject.SetActive(false);
        completeScanning?.Invoke();
        GameScene31Manager.ins.CompleteScanning();
    }
}
