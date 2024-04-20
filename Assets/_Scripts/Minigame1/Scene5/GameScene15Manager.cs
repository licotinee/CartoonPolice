using Spine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene15Manager : MonoBehaviour
{
    [SerializeField] ShadeBg startShade;
    [SerializeField] ShadeBg endShade;
    public static GameScene15Manager ins;
    [SerializeField] Wolfoo_Scene5_1 wolfoo;
    public Criminal_Scene5_1 criminal;
    public bool isStartGame;
    public bool isWolfooBeHitted;
    [SerializeField] SpawnObsable spawnObsable;
    [SerializeField] public float timeBeHitted;
    [SerializeField] int maxPoint;
    [SerializeField] float timeMax;
    float eslapsedTime;
    public int curPoint;
    public bool isEndGame;
    public float level;
    [SerializeField] List<float> levelScale;
    [SerializeField] Kat_Scene5_1 kat;
    [SerializeField] Camera_Scene5_1 cam;
    [SerializeField] List<Road_Scene5_1> listRoad;
    public bool isStopRoad;

    public int cntDestroyObsacle;
    public bool isStopSpawn;
    public bool isDraggedTutorial = false;
    private void Awake()
    {
        ins = this;
        level = levelScale[0];

        startShade.gameObject.SetActive(true);

        if (!PlayerPrefs.HasKey(CONSTANTS.FirstPlayScene1_6))
        {
            PlayerPrefs.SetInt(CONSTANTS.FirstPlayScene1_6, 1);
        }
    }

    private void Start()
    {
        StartCoroutine(StartScene());
    }
    public void Update()
    {
        RunTime();
    }
    public void UpdateLevel(int index)
    {
        level = levelScale[index];
    }

    private void RunTime()
    {
        if (isStartGame)
        {
            eslapsedTime += Time.deltaTime;
            if (eslapsedTime >= timeMax && !isStopSpawn)
            {
                StartCoroutine(StartEndGame());

            }
        }
    }
   
    IEnumerator StartEndGame()
    {
        isStopSpawn = true;
        spawnObsable.StopSpawn();

        while (cntDestroyObsacle != spawnObsable.cntSpawn)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1f + timeBeHitted);
        isEndGame = true;
        isStopRoad = true;
        wolfoo.EndGame(1f);
        criminal.EndGame(1f);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_witch_catched);
        kat.gameObject.SetActive(true);
        
        kat.EndGame(1f);
        yield return new WaitForSeconds(1f);
        cam.ScaleUp(1f);
        yield return new WaitForSeconds(2f);
        UIManager_Scene5_1.ins.TurnOnPointPanel();
        yield return new WaitForSeconds(2f);
        endShade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        LoadNextScene();
    }
   

    public void DeActiveTutorial()
    {
        
        isDraggedTutorial = true;
        PlayerPrefs.SetInt((CONSTANTS.FirstPlayScene1_6), 0);
        wolfoo.animTut.SetActive(false);
        wolfoo.spriteFocus.SetActive(false);
        isStopSpawn = false;
        wolfoo.skeleton.AnimationState.SetAnimation(0, "Run_Ninja2", true);
        criminal.skeleton.AnimationState.SetAnimation(0, "Run_c", true);
        isStopRoad = false;
    }
    private void LoadNextScene()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        int curScene = PlayerPrefs.GetInt("curScene") + 1;
        PlayerPrefs.SetInt("curScene", curScene);
        ScenesManager.ins.LoadScene(curMinigame + "." + curScene.ToString());
    }

    IEnumerator StartScene()
    {
        criminal.MoveToPosStartSpawn(1f);
        yield return new WaitForSeconds(1f);
        criminal.MoveToStartScene(1f);
        wolfoo.MoveToStartScene(1f);
        yield return new WaitForSeconds(1f);
        isStartGame = true;

        yield return new WaitForSeconds(1f);
        spawnObsable.Spawn();
        yield return new WaitForSeconds(0.5f);
       
        if(PlayerPrefs.GetInt(CONSTANTS.FirstPlayScene1_6) == 1 && !isDraggedTutorial)
        {
            isStopSpawn = true;
            this.ActiveTutorialScene1_6();
        }
        
    }
    private void ActiveTutorialScene1_6()
    {
        
        
        wolfoo.animTut.SetActive(true);
        wolfoo.spriteFocus.SetActive(true);
        wolfoo.skeleton.AnimationState.SetAnimation(0, "Idle", true);
        criminal.skeleton.AnimationState.SetAnimation(0, "Idle", true);
        isStopRoad = true;
        
    }

    public void WolfooBeHitted()
    {
        StartCoroutine(nameof(StartWolfooBeHitted));
    }

    IEnumerator StartWolfooBeHitted()
    {
        isWolfooBeHitted = true;
        criminal.Smiling();
        SoundManager.Instance.PlaySFX(SoundTag.Eff_witch_lol);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_wolfoo_crying);
        spawnObsable.StopSpawn();
        yield return new WaitForSeconds(timeBeHitted);
        isWolfooBeHitted = false;
        criminal.RunAgain();
        spawnObsable.Spawn();
        wolfoo.RunAgain();
    }

    public void UpdatePoint()
    {
        curPoint++;
        if (curPoint >= maxPoint)
        {
            curPoint = maxPoint;
        }
        UIManager_Scene5_1.ins.barPanel.UpdateBar(1.0f * curPoint/maxPoint);
    }
}
