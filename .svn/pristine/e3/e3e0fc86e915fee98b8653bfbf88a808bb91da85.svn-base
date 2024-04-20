using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnQuet : MonoBehaviour
{
    bool isCliked;
    Button btnActiveScanning;
    [SerializeField] GameObject mayQuetVanTay;
    private void Awake()
    {
        btnActiveScanning = GetComponent<Button>();
        btnActiveScanning.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        if (!isCliked)
        {
            isCliked = true;
            mayQuetVanTay.SetActive(true);
        }
    }
}
