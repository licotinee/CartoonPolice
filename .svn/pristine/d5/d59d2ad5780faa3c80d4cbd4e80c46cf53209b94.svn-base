using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarEnemy_Scene3_4 : MonoBehaviour
{
    [SerializeField] CarEnemy_Scene3_4 carEnemy;
    [SerializeField] List<Transform> posYSpawn;
    [SerializeField] float timeDelayToStartSpawn;
    [SerializeField] float timeDelaySpawn;

    Dictionary<int, string> DSkin = new Dictionary<int, string>()
    {
        {0, "Xe1"},
        {1, "Xe2"},
        {2, "Xe3"},
    };

    private void OnEnable()
    {
        GameScene43Manager.eEndGame += EndGame;
        GameScene43Manager.ePrepareEndGame += EndGame;
    }

    private void OnDestroy()
    {
        GameScene43Manager.eEndGame -= EndGame;
        GameScene43Manager.ePrepareEndGame -= EndGame;
    }

    private void Start()
    {
        StartCoroutine(nameof(StartSpawn));
    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(timeDelayToStartSpawn);
        int ranPosY;
        int ranSkin;
        Vector3 posSpawn;
        while (true)
        {
            ranPosY = Random.Range(0, posYSpawn.Count);
            posSpawn = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 3f, posYSpawn[ranPosY].position.y, transform.position.z);
            CarEnemy_Scene3_4 newCar = Instantiate(carEnemy, posSpawn, Quaternion.identity);
            ranSkin = Random.Range(0, DSkin.Count);
            newCar.SetUp(DSkin[ranSkin]);
            yield return new WaitForSeconds(timeDelaySpawn);
        }

    }

    protected void EndGame()
    {
        StopCoroutine(nameof(StartSpawn));
    }
}