using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene24Manager : MonoBehaviour
{
    public static GameScene24Manager ins;
    public int point;
    [SerializeField] int maxPoint;
    [SerializeField] public Police_SceneBank police;
    [SerializeField] SpawnCriminal_SceneBank spawnManager;
    [SerializeField] int pointAppearCriminalGun;
    private bool isEndGame;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    public delegate void EndScene();
    public event EndScene endScene;
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void UpdatePoint()
    {
        if (!isEndGame)
        {
            point++;
            BarPanel_SceneBank.ins.UpdateBar(1.0f * point / maxPoint);
            if (point == pointAppearCriminalGun)
            {
                spawnManager.StartSpawnCriminalGun();
            }
            if (point == maxPoint)
            {
                isEndGame = true;
                StartCoroutine(StartEndScene());
            }
        }

    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1f);
        endScene?.Invoke();
        yield return new WaitForSeconds(2f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNewScene();
    }

    private void LoadNewScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
