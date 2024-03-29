using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicBoard : MonoBehaviour
{
    [SerializeField] Sprite scene;

    [SerializeField] GameObject yellowRay;
    [SerializeField] GameObject Light;
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        UpdateScene();
    }

    public void UpdateScene()
    {
        StartCoroutine(StartUpDateScene());
    }

    IEnumerator StartUpDateScene()
    {
        sprite.sprite = scene;
        sprite.color = new Color(255, 255, 255, 0);
        float eslapsed = 0;
        float seconds = 1f;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            sprite.color = new Color(255, 255, 255, eslapsed/seconds);
            yield return new WaitForEndOfFrame();
        }
        sprite.color = new Color(255, 255, 255, 1);
    }

    public void TurnOnLight()
    {
        StartCoroutine(StartTurnOnLight());
    }

    IEnumerator StartTurnOnLight()
    {
        yellowRay.SetActive(true);
        Light.SetActive(true);
        float speed = 100f;
        while (true)
        {
            Light.transform.eulerAngles += new Vector3(0, 0, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
