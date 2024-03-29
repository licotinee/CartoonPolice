using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenuManager : MonoBehaviour
{
    public static SceneMenuManager ins;
    [SerializeField] GameObject sceneLoading;
    private void Awake()
    {
        ins = this;
    }

    public void PlayMinigame()
    {
        StartCoroutine(StartPlayMinigame());
    }

    IEnumerator StartPlayMinigame()
    {
        sceneLoading.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadMinigame();
    }
    private void LoadMinigame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene");
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }
}
