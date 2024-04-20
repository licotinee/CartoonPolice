using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameScene24Manager;

public class GameScene86Manager : MonoBehaviour
{
    public static GameScene86Manager ins;
    [SerializeField] public Criminal_Scene6_8 criminal;
    [SerializeField] private GameObject particleSystem;
    [SerializeField] private GameObject endScene;
   
    public bool isEndGame;
    public bool isStartGame;
    public ShadeBg endShade;
    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_wear);
    }

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }

    IEnumerator StartEndGame()
    {
   
        yield return new WaitForSeconds(0.5f);
        endShade.gameObject.SetActive(true);

        
        yield return new WaitForSeconds(1f);

        ScenesManager.ins.LoadScene("Scene8.7");
    }

    //private void CompleteMinigame8_6()
    //{
    //    //string curMinigame = PlayerPrefs.GetString("curMinigame");
    //    //LevelManager.ins.UpdateLevel(curMinigame);
        
    //}
}
