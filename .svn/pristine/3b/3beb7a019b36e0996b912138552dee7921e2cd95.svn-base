using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager_Scene5_1 : MonoBehaviour
{
    public static UIManager_Scene5_1 ins;
    [SerializeField] public BarProgress_Scene5_1 barPanel;
    [SerializeField] public PointPanel_Scene5_1 pointPanel;
    private void Awake()
    {
        ins = this;
    }

    public void TurnOnPointPanel()
    {
        barPanel.gameObject.SetActive(false);
        pointPanel.gameObject.SetActive(true);
    }
}
