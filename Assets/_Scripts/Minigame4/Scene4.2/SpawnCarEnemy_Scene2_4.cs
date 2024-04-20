using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarEnemy_Scene2_4 : Singleton<SpawnCarEnemy_Scene2_4>
{
    Dictionary<int, string> DSkin = new Dictionary<int, string>()
    {
        {0, "EnemyTruck/EnemyRed"},
        {1, "EnemyTruck/EnemyBlack"},
        {2, "EnemyTruck/EnemyBlue"},
        {3, "EnemyTruck/EnemyGreen"},
        {4, "EnemyTruck/EnemyOrange"},
    };

    [SerializeField] CarEnemy_Scene2_4 carEnemy;
    [SerializeField] List<Transform> ListPosSpawnCar;
    [SerializeField] CarEnemy_Scene2_4 bossCar;
    [SerializeField] float timeDelaySpawn;
    
    

    private void Awake()
    {
        base.Awake();
        if (!PlayerPrefs.HasKey(CONSTANTS.FirstPlayScene4_2))
        {
            PlayerPrefs.SetInt(CONSTANTS.FirstPlayScene4_2, 1);
        }
    }
    private void Start()
    {
       
        if (PlayerPrefs.GetInt(CONSTANTS.FirstPlayScene4_2) == 1)
        {
            this.SpawnCarTutorial(); 
            return;
        }
       
        StartCoroutine(nameof(StartSpawn));

    }

    private void OnEnable()
    {
        GameScene42Manager.eEndGame += EndGame;
        GameScene42Manager.eChangeScene += ChangeScene;

    }

    private void OnDestroy()
    {
        GameScene42Manager.eEndGame -= EndGame;
        GameScene42Manager.eChangeScene -= ChangeScene;

    }


    private int ranPos;
    private int ranSkin;
    private int ranMoveFast;

    private void SpawnCarTutorial()
    {      
        CarEnemy_Scene2_4 newCar = Instantiate(carEnemy, ListPosSpawnCar[1].position, Quaternion.identity);
        newCar.isCarTutorial = true;
        ranSkin = Random.Range(0, DSkin.Count);
        ranMoveFast = Random.Range(0, 3);
        //newCar.SetUp(DSkin[ranSkin], false);
        newCar.SetUpCarTutorial(DSkin[ranSkin]);

    }

    public void StartSpawnCar()
    {
        StartCoroutine(nameof(StartSpawn));
    }
    IEnumerator StartSpawn()
    {
        while (true)
        {
            ranPos = Random.Range(0, ListPosSpawnCar.Count);
            CarEnemy_Scene2_4 newCar = Instantiate(carEnemy, ListPosSpawnCar[ranPos].position, Quaternion.identity);
            ranSkin = Random.Range(0, DSkin.Count);
            ranMoveFast = Random.Range(0, 3);
            newCar.SetUp(DSkin[ranSkin], ranMoveFast < 2);
            yield return new WaitForSeconds(timeDelaySpawn);
        }

    }

    private void EndGame()
    {
        StopCoroutine(nameof(StartSpawn));
    }

    private void ChangeScene()
    {
        bossCar.gameObject.SetActive(true);
    }
}
