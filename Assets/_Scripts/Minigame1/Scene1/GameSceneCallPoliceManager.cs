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

    private void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_intro);
    }
    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    public void SkipScene()
    {
        StartCoroutine(StartSkipScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        SoundManager.Instance.StopCurrentBG();
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.StopSfxLoop();
        LoadNextScene();
    }

    IEnumerator StartSkipScene()
    {
        yield return new WaitForSeconds(0.5f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        SoundManager.Instance.StopSfxLoop();
        SoundManager.Instance.StopCurrentBG();
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
