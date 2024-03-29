using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene30Manager : MonoBehaviour
{
    public static GameScene30Manager ins;
    [SerializeField] GameObject Scene1;
    [SerializeField] GameObject Scene2;
    [SerializeField] Police_Scene0_3 police;
    [SerializeField] ShadeBg endShade;
    private void Awake()
    {
        ins = this;
    }

    public void CompleteScene1()
    {
        Scene1.SetActive(false);
        Scene2.SetActive(true);
        police.MoveToEndPos();
    }

    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1.5f);
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
