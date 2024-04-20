using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarEnemy_Scene2_4 : MonoBehaviour
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
    private void Start()
    {
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
