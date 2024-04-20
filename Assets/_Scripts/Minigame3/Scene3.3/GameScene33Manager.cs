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
    private void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_child_gohome);
    }
    public void EndScene()
    {
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(1f);
        particleSystem.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundTag.Eff_paper_firework_particle);
        yield return new WaitForSeconds(2f);
        endScene.gameObject.SetActive(true);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_reward_star);
        yield return new WaitForSeconds(3f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        CompleteMinigame();
    }
    private void CompleteMinigame()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_home);
        ScenesManager.ins.LoadScene("SceneMenu");

    }
}
