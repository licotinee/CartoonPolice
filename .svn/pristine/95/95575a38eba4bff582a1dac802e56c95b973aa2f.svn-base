using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene52Manager : MonoBehaviour
{
    public static GameScene52Manager ins;
    [SerializeField] StarManagerScene52 starManager;
    [SerializeField] BarScene52Manager barManager;
    private int point;
    [SerializeField] int maxPoint;
    [SerializeField] GameObject boostSystem;
    public bool isEndGame;
    [SerializeField] GameObject policeStation;


    public float scaleSpeed;
    [SerializeField] float timeSpeedUp;
    [SerializeField] SteeringWheel steering;


    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;

    public delegate void EEndGame();
    public static event EEndGame eEndGame;

    private void Awake()
    {
        scaleSpeed = 1;
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void UpdatePoint()
    {
        point++; 
        if (point >= maxPoint)
        {
            if (!isEndGame)
            {
                isEndGame = true;
                EndScene();
            }
        }
        starManager.UpdatePosIcon(1.0f * point / maxPoint);
        barManager.UpdateBarFill(1.0f * point / maxPoint);

    }

    private void EndScene()
    {
        StartCoroutine(nameof(StartEndScene));

    }

    public void SpeedUp()
    {
        StartCoroutine(nameof(StartToSpeedUp));
    }

    IEnumerator StartToSpeedUp()
    {
        scaleSpeed = 2f;
        boostSystem.SetActive(true);
        yield return new WaitForSeconds(timeSpeedUp);
        scaleSpeed = 1f;
        boostSystem.SetActive(false);
    }


    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(timeSpeedUp);
        policeStation.SetActive(true);
        steering.EndScene();
        eEndGame?.Invoke();
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNewScene();
    }

    public void LoadNewScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
