using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene84Manager : MonoBehaviour
{
    public static GameScene84Manager ins;
    public ShadeBg startShade;
    public ShadeBg endShade;
    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_suspect_hint);
    }
    public void LoadNewScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(curMinigame + ".5");
    }
}
