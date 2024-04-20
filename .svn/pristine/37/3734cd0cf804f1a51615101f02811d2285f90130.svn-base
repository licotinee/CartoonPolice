using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneCallPolice {
    public class MapManager : MonoBehaviour
    {
        [SerializeField] List<Image> listMaps;
        Image image;
        private void Awake()
        {
            image = GetComponent<Image>();
            image.color = new Color(255, 255, 255, 0);
        }
        private void OnEnable()
        {
            string curMinigame = PlayerPrefs.GetString("curMinigame");
            int curLevel = LevelManager.ins.GetLevel(curMinigame);
            listMaps[curLevel % listMaps.Count].gameObject.SetActive(true);
        }


    }

}
