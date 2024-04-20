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
    private void Start()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");

        SoundManager.Instance.PlayBGM(SoundTag.Bgm_jail);
        if(curMinigame == "Scene4")
        {
            SoundManager.Instance.PlaySFX(SoundTag.Eff_panther_boring);
        }
        SoundManager.Instance.PlaySFX(SoundTag.Eff_witch_boring);
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
        endScene.gameObject.SetActive(true);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_reward_star);
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        CompleteMiniGame();
    }

    private void CompleteMiniGame()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_home);
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
