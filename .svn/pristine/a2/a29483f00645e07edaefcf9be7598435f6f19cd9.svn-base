using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoading : MonoBehaviour
{
    [SerializeField] List<GameObject> listWolfoosLoading;
    [SerializeField] float timeDelayLoad;
    private void OnEnable()
    {
        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        int index = 0;
        int max = listWolfoosLoading.Count;
        while (gameObject)
        {
            listWolfoosLoading[(index - 1 + max) % max].SetActive(false);
            listWolfoosLoading[(index + max) % max].SetActive(true);
            index++;
            yield return new WaitForSeconds(timeDelayLoad);
        }
    }
}
