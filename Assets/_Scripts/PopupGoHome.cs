using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using DG.Tweening;
public class PopupGoHome : MonoBehaviour
{
    [SerializeField] Button btnYesGoHome;
    [SerializeField] GameObject shadeBg;
    private void Start()
    {
        btnYesGoHome.onClick.AddListener(() => this.ConfirmGoHome());
    }

    private void ConfirmGoHome()
    {
        StartCoroutine(GoMainMenu());
    }

    IEnumerator GoMainMenu()
    {
        SoundManager.Instance.PlaySFX(SoundTag.Eff_button_08);
        yield return new WaitForSeconds(0.5f);
        shadeBg.SetActive(true);
        SoundManager.Instance.StopCurrentBG();
        SoundManager.Instance.StopCurrentSFX();
        SoundManager.Instance.StopSfxLoop();
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_home);

        shadeBg.GetComponent<Image>().DOFade(1f, 2f).OnComplete(() => 
        {
            SceneManager.LoadScene(1);
        });

    }
}
