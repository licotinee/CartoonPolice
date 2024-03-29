using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Spine.Unity;
using Unity.VisualScripting;

public class Scene8_5Manager : Singleton<Scene8_5Manager>
{
    public ConfigIndex configMap1;
    public List<ConfigIndex>listConfigMap;
    public List<ItemScene8_5> listMapsItems;
    [SerializeField] private GameObject door;
    [SerializeField] public List<SkeletonAnimation> listCriminalSkele;
    [SerializeField] private List<SkeletonAnimation> listCriminalSkeleInGame;
    [SerializeField] private List<GameObject> listMapCriminalSpawn;
    [SerializeField] private List<Button> buttonsCriminal;
    [SerializeField] private List<Button> buttonsCriminalInGame;
    [SerializeField] private List<Vector3> posSpawnAnim;
    [SerializeField] private List<Vector3> posButton;
    [SerializeField] private Transform transformSpawnCriminal;
    [SerializeField] private SpriteRenderer spriteItemInGame;
    [SerializeField] private SkeletonAnimation policeWolfoo;
    [SerializeField] private SkeletonAnimation policeKat;
    [SerializeField] private ShadeBg endShade;

    public List<int> correctIndexByStep;
    public int countCorrect = 0;
    public int step = 0;
    private int curLevelScene8;

   
    void Start()
    {
        curLevelScene8 = PlayerPrefs.GetInt("LevelScene8", 0) % 3;
        StartCoroutine(AnimDoor());
        foreach (var item in buttonsCriminal)
        {
            buttonsCriminalInGame.Add(item);
        }
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
        door.transform.DOMove(new Vector3(0, 20, 0), 2f);
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
                GameObject go = Instantiate(listMapCriminalSpawn[curLevelScene8], transformSpawnCriminal);
                go.transform.position = Vector3.zero;
                spriteItemInGame.sprite = listMapsItems[curLevelScene8].listSpriteItems[0];
                policeWolfoo.AnimationState.SetAnimation(0, "Idle", true);
                policeKat.AnimationState.SetAnimation(0, "Idle", true);
                break;

            //case 1 
            case 1:
                listCriminalSkeleInGame.Clear();
                buttonsCriminalInGame.Clear();
                this.DeActiveAllAnimObject();
                this.DeActiveAllButtonCriminal();
              foreach (int i in correctIndexByStep)
              {
                    listCriminalSkele[i].gameObject.SetActive(true);
                    listCriminalSkeleInGame.Add(listCriminalSkele[i]);
                    buttonsCriminal[i].gameObject.SetActive(true);
                    buttonsCriminalInGame.Add(buttonsCriminal[i]);


                }
              for (int i = 0; i < listCriminalSkeleInGame.Count; i++)
                {
                    listCriminalSkeleInGame[i].gameObject.transform.position = posSpawnAnim[i+1];
                    buttonsCriminalInGame[i].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[i+1];

                }
                spriteItemInGame.sprite = listMapsItems[curLevelScene8].listSpriteItems[1];
                policeWolfoo.AnimationState.SetAnimation(0, "Idle", true);
                policeKat.AnimationState.SetAnimation(0, "Idle", true);
                break;

            //case 2
            case 2:
                listCriminalSkeleInGame.Clear();
                buttonsCriminalInGame.Clear();
                this.DeActiveAllAnimObject();
                this.DeActiveAllButtonCriminal();
                foreach (int i in correctIndexByStep)
                {
                    listCriminalSkele[i].gameObject.SetActive(true);
                    listCriminalSkeleInGame.Add(listCriminalSkele[i]);


                    buttonsCriminal[i].gameObject.SetActive(true);
                    buttonsCriminalInGame.Add(buttonsCriminal[i]);


                }
                for (int i = 0; i < listCriminalSkeleInGame.Count; i++)
                {
                    listCriminalSkeleInGame[i].gameObject.transform.position = posSpawnAnim[i + 1];
                    buttonsCriminalInGame[i].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[i + 1];

                }

                listCriminalSkeleInGame[0].gameObject.transform.position = posSpawnAnim[1];
                listCriminalSkeleInGame[1].gameObject.transform.position = posSpawnAnim[3];
                buttonsCriminalInGame[0].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[1];
                buttonsCriminalInGame[1].gameObject.GetComponent<RectTransform>().anchoredPosition = posButton[3];
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

    public void ClickButtonOnCriminal(int i )
    {
        foreach (int item in correctIndexByStep)
        {
            if(item == i)
            {
                //SoundManager.Instance.PlaySFX(SoundTag.Eff_success_01);
                SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_success_02);
                listCriminalSkele[i].AnimationState.SetAnimation(0,"Angry", false);
                buttonsCriminal[i].interactable = false;
                countCorrect++;
                if(countCorrect >= correctIndexByStep.Count)
                {
                    this.SetAnimPoliceClapHandAndNextStep();
                }
                if(countCorrect >= correctIndexByStep.Count && step >= 2)
                {
                    this.SetAnimWinGame();
                }
            }
            else
            {
                //SoundManager.Instance.PlaySFX(SoundTag.Eff_fail_01);
                SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_fail_02);
            }
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

    private void DeActiveAllButtonCriminal()
    {
        foreach (var item in buttonsCriminal)
        {
            item.interactable = true;
            item.gameObject.SetActive(false);
        }
    }
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