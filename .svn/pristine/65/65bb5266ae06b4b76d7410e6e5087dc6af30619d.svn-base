using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneIntro5_1
{
    public class GameSceneManager : MonoBehaviour
    {
        public static GameSceneManager ins;
        [SerializeField] ShadeBg startShade;
        [SerializeField] ShadeBg endShade;
        private void Awake()
        {
            ins = this;
            startShade.gameObject.SetActive(true);
        }

        public void EndScene()
        {
            StartCoroutine(StartEndScene());
        }

        IEnumerator StartEndScene()
        {
            endShade.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            LoadNextScene();
        }

        public void LoadNextScene()
        {
            string curMinigame = PlayerPrefs.GetString("curMinigame");
            int curScene = PlayerPrefs.GetInt("curScene") + 1;
            PlayerPrefs.SetInt("curScene", curScene);
            ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
        }
    }
}

