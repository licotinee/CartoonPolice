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

    public void EndGame()
    {
        StartCoroutine(StartEndGame());
    }

    IEnumerator StartEndGame()
    {
        Handheld.Vibrate();
        isEndGame = true;
        particleSystem.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundTag.Eff_paper_firework_particle);

        yield return new WaitForSeconds(2f);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_reward_star);
        endScene.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);

        
        yield return new WaitForSeconds(1f);
        
        CompleteMinigame8();
    }

    private void CompleteMinigame8()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
