using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Spine.Unity;
using Unity.VisualScripting;
using Spine;

public class Scene8_5Manager : Singleton<Scene8_5Manager>
{
    public ConfigIndex configMap1;
    public List<ConfigIndex>listConfigMap;
    public List<ItemScene8_5> listMapsItems;
    [SerializeField] private GameObject door;
    [SerializeField] public List<SkeletonAnimation> listCriminalSkele;
    [SerializeField] private List<SkeletonAnimation> listCriminalSkeleInGame;
    [SerializeField] private List<GameObject> listMapCriminalSpawn;
    //[SerializeField] private List<Button> buttonsCriminal;
    //[SerializeField] private List<Button> buttonsCriminalInGame;
    [SerializeField] private List<Vector3> posSpawnAnim;
    //[SerializeField] private List<Vector3> posButton;
    [SerializeField] private Transform transformSpawnCriminal;
    [SerializeField] private SpriteRenderer spriteItemInGame;
    [SerializeField] private SkeletonAnimation policeWolfoo;
    [SerializeField] private SkeletonAnimation policeKat;
    [SerializeField] private ShadeBg endShade;
    [SerializeField] private List<GameObject> scanHandMachines;
    [SerializeField] private SkeletonAnimation scanMachinePolice;
    [SerializeField] private GameObject hands;
    [SerializeField] private GameObject round_2;
    [SerializeField] private GameObject BG_Round_2;
    [SerializeField] private GameObject polices;


    public List<int> correctIndexByStep;
    public int countCorrect = 0;
    public int step = 0;
    private int curLevelScene8;

   
    void Start()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_theif_find);
        curLevelScene8 = PlayerPrefs.GetInt("LevelScene8", 0) % 3;
        
        GameObject go = Instantiate(listMapCriminalSpawn[curLevelScene8], transformSpawnCriminal);
        go.transform.position = Vector3.zero;
        StartCoroutine(AnimDoor());
        //foreach (var item in buttonsCriminal)
        //{
        //    buttonsCriminalInGame.Add(item);
        //}
        //for (int i = 0; i < buttonsCriminal.Count; i++)
        //{
        //    buttonsCriminal[i].interactable = true;
        //}
    }

    IEnumerator AnimDoor()
    {
        door.transform.DOMove(Vector3.zero, 0.75f).OnComplete(() => 
        {
            this.SetUpNextStep(step);
            
        });
        yield return new WaitForSeconds(1f);
        door.transform.DOMove(new Vector3(0, 18, 0), 2f);
    }
    
    private void SetUpNextStep(int indexStep)
    {
        

        switch (indexStep)
        {
            // case0
            case 0:

               

                foreach (var item in listCriminalSkele)
                {
                    listCriminalSkeleInGame.Add(item);
                }
               
                spriteItemInGame.sprite = listMapsItems[curLevelScene8].listSpriteItems[0];
                policeWolfoo.AnimationState.SetAnimation(0, "Idle", true);
                policeKat.AnimationState.SetAnimation(0, "Idle", true);
                break;

            //case 1 
            case 1:
                listCriminalSkeleInGame.Clear();
                //buttonsCriminalInGame.Clear();
                this.DeActiveAllAnimObject();
                //this.DeActiveAllButtonCriminal();
                  foreach (int i in correctIndexByStep)
                  {
                        listCriminalSkele[i].gameObject.SetActive(true);
                        listCriminalSkeleInGame.Add(listCriminalSkele[i]);
                        //buttonsCriminal[i].gameObject.SetActive(true);
                        //buttonsCriminalInGame.Add(buttonsCriminal[i]);


                  }
                  for (int i = 0; i < listCriminalSkeleInGame.Count; i++)
                  {
                        listCriminalSkeleInGame[i].gameObject.transform.position = posSpawnAnim[i];
                    listCriminalSkeleInGame[i].GetComponent<ClickSelectCriminal>().canClick = true;
                    listCriminalSkeleInGame[i].transform.GetChild(1).gameObject.SetActive(false);
                    listCriminalSkeleInGame[i].transform.GetChild(0).gameObject.SetActive(false);

                    //buttonsCriminalInGame[i].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[i+1];

                }

                spriteItemInGame.sprite = listMapsItems[curLevelScene8].listSpriteItems[1];
                policeWolfoo.AnimationState.SetAnimation(0, "Idle", true);
                policeKat.AnimationState.SetAnimation(0, "Idle", true);
                round_2.SetActive(true);
                StartCoroutine(AnimScanHandAndSetup());
                


                break;

            //case 2
            case 2:
                listCriminalSkeleInGame.Clear();
                //buttonsCriminalInGame.Clear();
                this.DeActiveAllAnimObject();
                //this.DeActiveAllButtonCriminal();
                foreach (int i in correctIndexByStep)
                {
                    listCriminalSkele[i].gameObject.SetActive(true);
                    listCriminalSkeleInGame.Add(listCriminalSkele[i]);


                    //buttonsCriminal[i].gameObject.SetActive(true);
                    //buttonsCriminalInGame.Add(buttonsCriminal[i]);


                }
                for (int i = 0; i < listCriminalSkeleInGame.Count; i++)
                {
                    listCriminalSkeleInGame[i].gameObject.transform.position = posSpawnAnim[i + 1];
                    //buttonsCriminalInGame[i].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[i + 1];

                }

                listCriminalSkeleInGame[0].gameObject.transform.position = posSpawnAnim[1];
                listCriminalSkeleInGame[1].gameObject.transform.position = posSpawnAnim[3];
                //buttonsCriminalInGame[0].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[1];
                //buttonsCriminalInGame[1].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[3];
                policeWolfoo.gameObject.SetActive(false);
                policeKat.gameObject.SetActive(false);
                //policeWolfoo.AnimationState.SetAnimation(0, "Idle", false);
                //policeKat.AnimationState.SetAnimation(0, "Idle", false);
               

                break;
        }

        correctIndexByStep.Clear();
        countCorrect = 0;

        foreach (int i in listConfigMap[curLevelScene8].listIdx[indexStep].listIndex)
        {
            correctIndexByStep.Add(i);
            //buttonsCriminal[i].interactable = true;
        }
    }

    IEnumerator AnimScanHandAndSetup()
    {
        yield return new WaitForSeconds(1.5f);
        polices.transform.DOMove(new Vector3(0, -9f, 0), 1f);
        
        

        scanMachinePolice.AnimationState.SetAnimation(0, "Scan", false);
        yield return new WaitForSeconds(4.1f);
        hands.transform.DOMove(Vector3.zero, 1.5f);
        for (int i = 0; i < scanHandMachines.Count; i++)
        {
            scanHandMachines[i].GetComponent<ClickSelectCriminal>().id_Criminal = listCriminalSkeleInGame[i].GetComponent<ClickSelectCriminal>().id_Criminal;
            Sprite spriteFingerPrints;
            spriteFingerPrints = listCriminalSkeleInGame[i].GetComponent<ClickSelectCriminal>().spriteFingerPrints;
            scanHandMachines[i].GetComponent<ClickSelectCriminal>().spriteFingerPrints = spriteFingerPrints;
            if (scanHandMachines[i].gameObject.transform.GetChild(0) != null)
            {
                scanHandMachines[i].gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteFingerPrints;
            }
        }
        yield return new WaitForSeconds(1.75f);

        foreach (var item in scanHandMachines)
        {

            if (item.transform.GetChild(0) != null)
            {
                item.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        hands.transform.DOMove(new Vector3(0, -10f, 0), 1.5f);
        
      
       





    }

    public void ClickOnCriminal(int i)
    {
        bool isCriminalCorrect = false;
        foreach (int item in correctIndexByStep)
        {
            if (item == i) isCriminalCorrect=true;
            continue;
        }

        
            if (isCriminalCorrect)
            {
            //SoundManager.Instance.PlaySFX(SoundTag.Eff_success_01);
            SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_success_02);
            //listCriminalSkele[i].AnimationState.SetAnimation(0, "Angry", false);
            //buttonsCriminal[i].interactable = false;
            countCorrect++;
                Debug.LogError("chon dung");
                listCriminalSkele[i].GetComponent<ClickSelectCriminal>().canClick = false;
                listCriminalSkele[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                if (countCorrect >= correctIndexByStep.Count && step >= 1)
                {
                    this.SetAnimWinGame();
                }
                else if (countCorrect >= correctIndexByStep.Count)
                {
                    this.SetAnimPoliceClapHandAndNextStep();
                }
                
            }
            else
            {
            //SoundManager.Instance.PlaySFX(SoundTag.Eff_fail_01);
            SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_fail_02);
            Debug.LogError("chon sai");
                listCriminalSkele[i].gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
        
        this.SetAnimAngry(listCriminalSkele[i]);
        StartCoroutine(SetAnimIdle(listCriminalSkele[i]));
    }

    private void SetAnimWinGame()
    {
        policeKat.gameObject.transform.position = new Vector3(6,-10f,0);
        policeWolfoo.gameObject.transform.position = new Vector3(-6,-10f,0);
        policeKat.gameObject.SetActive(true);
        policeWolfoo.gameObject.SetActive(true);
        policeKat.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        policeKat.gameObject.transform.DOMove(new Vector3(6, -5.5f, 0), 0.75f);
        policeWolfoo.gameObject.transform.DOMove(new Vector3(-6, -5.5f, 0), 0.75f).OnComplete(() => { SoundManager.Instance.PlaySFX(SoundTag.Eff_cheer_smallwin); });
        policeWolfoo.AnimationState.SetAnimation(0, "Cheer", true);
        policeKat.AnimationState.SetAnimation(0, "Cheer", true);
        StartCoroutine(LoadNewScene());

    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(3);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(curMinigame + ".6");
    }
    private void SetAnimPoliceClapHandAndNextStep()
    {
        policeWolfoo.AnimationState.SetAnimation(0, "Clap_Hand", true);
        policeKat.AnimationState.SetAnimation(0, "Clap_Hand", true);
        StartCoroutine(WaitAndNextStep());
    }

    IEnumerator WaitAndNextStep()
    {
        yield return new WaitForSeconds(2f);
        this.NextStep();     
    }

    private void SetAnimAngry(SkeletonAnimation skeleton)
    {
        skeleton.AnimationState.SetAnimation(0, "Angry", false);
        
    }

    IEnumerator SetAnimIdle(SkeletonAnimation skeleton)
    {
        yield return new WaitForSeconds(1.5f);
        skeleton.AnimationState.SetAnimation(0, "Idle", true);
        skeleton.gameObject.transform.GetChild(1).gameObject.SetActive(false);

    }


    private void NextStep()
    {
        step++;
        if (step < 3 ) {
            StartCoroutine(AnimDoor());
        }       
    }

    private void DeActiveAllAnimObject()
    {
        foreach (var item in listCriminalSkele)

        {
            item.gameObject.SetActive(false);
        }
    }

    //private void DeActiveAllButtonCriminal()
    //{
    //    foreach (var item in buttonsCriminal)
    //    {
    //        item.interactable = true;
    //        item.gameObject.SetActive(false);
    //    }
    //}
}

[Serializable]
public class ItemScene8_5
{
    public List<Sprite> listSpriteItems;
}

[Serializable]
public class ConfigIndex
{
     public List<ListIndex> listIdx;
}

[Serializable]
public class ListIndex
{
   
    public List<int> listIndex;
}