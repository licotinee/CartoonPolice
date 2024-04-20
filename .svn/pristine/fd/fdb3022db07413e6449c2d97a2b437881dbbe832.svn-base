using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionShirt_8 : MonoBehaviour
{
    public static SessionShirt_8 ins;
    private void Awake()
    {
        ins = this;
    }
    [SerializeField] public Screen_SessionShirt_8 screen;
    [SerializeField] Clip_SessionShirt_8 clip;

    private void OnEnable()
    {
        StartCoroutine(StartPlaySession());
    }

    IEnumerator StartPlaySession()
    {
        screen.ScaleUp(0.5f);
        yield return new WaitForSeconds(0.5f);
        clip.gameObject.SetActive(true);
        clip.MoveUp(0.5f);
    }
}
