using System.Collections;
using System.Collections.Generic;
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
    public bool isStopRoad;

    public int cntDestroyObsacle;
    public bool isStopSpawn;
    private void Awake()
    {
        ins = this;
        level = levelScale[0];

        startShade.gameObject.SetActive(true);
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
    }

    public void WolfooBeHitted()
    {
        StartCoroutine(nameof(StartWolfooBeHitted));
    }

    IEnumerator StartWolfooBeHitted()
    {
        isWolfooBeHitted = true;
        criminal.Smiling();
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
