using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene33Manager : MonoBehaviour
{
    public static GameScene33Manager ins;
    [SerializeField] public MomKid momKid;
    [SerializeField] GameObject endScene;
    [SerializeField] GameObject particleSystem;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1f);
        particleSystem.SetActive(true);
        yield return new WaitForSeconds(2f);
        endScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        CompleteMinigame();
    }
    private void CompleteMinigame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");

    }
}
