using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene53Manager : MonoBehaviour
{
    public static GameScene53Manager ins;
    [SerializeField] GameObject endScene;
    [SerializeField] GameObject particleSystem;
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
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
        Handheld.Vibrate();
        particleSystem.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundTag.Eff_paper_firework_particle);

        yield return new WaitForSeconds(2f);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_reward_star); 
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
