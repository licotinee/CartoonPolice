using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneCallPoliceManager : MonoBehaviour
{
    public static GameSceneCallPoliceManager ins;
    [SerializeField] ShadeBg endShade;
    private void Awake()
    {
        ins = this;
    }

    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNextScene();
    }
    private void LoadNextScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }

}
