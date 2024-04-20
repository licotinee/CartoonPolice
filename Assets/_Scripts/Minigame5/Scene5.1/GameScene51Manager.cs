using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene51Manager : MonoBehaviour
{
    public static GameScene51Manager ins;
    public CarWash car;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    private void Awake()
    {
        ins = this;
        startShade.gameObject.SetActive(true);
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_car_wash);
    }
    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        yield return new WaitForSeconds(1f);
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
