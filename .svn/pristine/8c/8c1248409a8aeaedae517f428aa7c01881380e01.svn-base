using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenePrisionManager : MonoBehaviour
{
    public static GameScenePrisionManager ins;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    [SerializeField] GameObject endScene;
    [SerializeField] GameObject particleSystem;
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }


    public void ActiveEndScene()
    {
        StartCoroutine(nameof(StartEndScene));
    }

    IEnumerator StartEndScene()
    {
        particleSystem.SetActive(true);
        yield return new WaitForSeconds(2f);
        endScene.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        CompleteMiniGame();
    }

    private void CompleteMiniGame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
