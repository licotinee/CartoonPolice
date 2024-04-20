using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSkipSceneCallPolice : MonoBehaviour
{
    [SerializeField] Button btnSkipSceneCallPolice;
    private void Start()
    {
        btnSkipSceneCallPolice.onClick.AddListener(() => { this.SkipSceneCallPolice(); });
    }
    private void SkipSceneCallPolice()
    {
        SoundManager.Instance.PlaySFX(SoundTag.Eff_button_08);
        GameSceneCallPoliceManager.ins.SkipScene();
    }
}
