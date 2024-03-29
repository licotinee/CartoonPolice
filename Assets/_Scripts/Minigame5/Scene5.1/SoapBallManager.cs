using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBallManager : MonoBehaviour
{
    int enableSoapBalls;
    int clearSoapBalls;
    [SerializeField] List<GameObject> SoapBalls;
    [SerializeField] float timeWashMax;
    List<float> timeWash;
    public delegate void EEndShower();
    public static event EEndShower eEndShower;

    public delegate void ECleanSoapBall(List<GameObject> ListSoapBall);
    public static ECleanSoapBall eCleanSoapBall;

    public delegate void EEnableSoapbBall();
    public static EEnableSoapbBall eEnableSoapBall;

    private void OnEnable()
    {
        eCleanSoapBall += Clean;
        eEnableSoapBall += UpdateEnableSoapBall;
    }

    private void OnDestroy()
    {
        eCleanSoapBall -= Clean;
        eEnableSoapBall -= UpdateEnableSoapBall;
    }

    private void Start()
    {
        timeWash = new List<float>(SoapBalls.Count);
        for(int i = 0; i < SoapBalls.Count; i++)
        {
            timeWash.Add(0);
        }
    }
    private void UpdateEnableSoapBall()
    {
        enableSoapBalls++;
        if (enableSoapBalls == SoapBalls.Count)
        {
            ToolManager.ins.StartShower();
            GameScene51Manager.ins.car.ClearDirt();
        }
    }

    private void Clean(List<GameObject> ListSoapBall)
    {
        foreach (GameObject soapBall in ListSoapBall)
        {
            this.CleanSoapBall(soapBall);
        }
    }
    private void CleanSoapBall(GameObject soapBall)
    {
        int index = SoapBalls.IndexOf(soapBall);
        timeWash[index] += Time.deltaTime;
        if (timeWash[index] >= timeWashMax)
        {
            Destroy(soapBall);
            UpdateClearSoapBall();
        }
    }

    private void UpdateClearSoapBall()
    {
        clearSoapBalls++;
        if (clearSoapBalls == SoapBalls.Count / 2)
        {
            GameScene51Manager.ins.car.ActivewaterSpriteCar();
        }
        if (clearSoapBalls == SoapBalls.Count)
        {
            eEndShower?.Invoke();
            ToolManager.ins.StartTowel();
        }
    }
}
