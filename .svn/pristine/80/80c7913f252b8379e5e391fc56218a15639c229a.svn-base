using SCN.UIExtend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroScenePanel : MonoBehaviour
{
    [SerializeField] CustomButton playButton;

    private void Awake()
    {
        playButton.OnClick.AddListener(delegate
        {
            ScenesManager.ins.LoadScene("SceneMenu");
        });
    }
}
