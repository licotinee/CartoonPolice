using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Session1_8 : MonoBehaviour
{
    [SerializeField] Wolf_Session_8 wolfoo;
    [SerializeField] Kat_Session_8 kat;

    [SerializeField] float timeMove;

    [SerializeField] Button finger;
    [SerializeField] Button foot;
    [SerializeField] Button shirt;
    [SerializeField] Image backgroundImage;
    [SerializeField] Image fingerImage;
    [SerializeField] Image footImage;
    [SerializeField] Image shirtImage;
    [SerializeField] Image zoomFootImage;
    [SerializeField] Image zoomClothesBGImage;
    [SerializeField] Image zoomClothesImage;

    [Header("Background Resource Set")]
    [SerializeField] Sprite[] backgroundSprite;
    [SerializeField] Sprite[] fingerSprite;
    [SerializeField] Sprite[] footSprite;
    [SerializeField] Sprite[] clothesSprite;
    [SerializeField] Sprite[] zoomClothesBackSprite;
    [SerializeField] Sprite[] zoomFootPrintSprite;
    [SerializeField] Transform[] fingerprintPos;
    [SerializeField] Transform[] footprintPos;
    [SerializeField] Transform[] clothesprintPos;
    [SerializeField] Transform[] clothesprintZoomPos;

    int backgroundId;
    int thiefID;

    private void Start()
    {
        PlaySession();
    }

    void PlaySession()
    {
        int curLevelScene8 = PlayerPrefs.GetInt("LevelScene8", 0) % 3;  
        
        backgroundId = curLevelScene8;
        thiefID = curLevelScene8;
        
       
        
        backgroundImage.sprite = backgroundSprite[backgroundId];
        zoomFootImage.sprite = zoomFootPrintSprite[backgroundId];
        zoomClothesBGImage.sprite = zoomClothesBackSprite[backgroundId];

        finger.transform.DOMove(fingerprintPos[backgroundId].position, 0);
        foot.transform.DOMove(footprintPos[backgroundId].position, 0);
        shirt.transform.DOMove(clothesprintPos[backgroundId].position, 0);
        zoomClothesImage.transform.DOMove(clothesprintZoomPos[backgroundId].position, 0);

        fingerImage.sprite = fingerSprite[thiefID];
        shirtImage.sprite = clothesSprite[thiefID];
        footImage.sprite = footSprite[thiefID];
        zoomClothesImage.sprite = clothesSprite[thiefID];
        StartCoroutine(StartSession());
    }

    IEnumerator StartSession()
    {
        wolfoo.MoveUp(timeMove);
        kat.MoveUp(timeMove);

        yield return new WaitForSeconds(timeMove + 1.5f);

        wolfoo.MoveDown(timeMove);
        kat.MoveDown(timeMove);

        yield return new WaitForSeconds(timeMove);
        SessionManager_8.ins.EnableNextSession();
    }
}
