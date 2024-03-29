using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCriminal_SceneBank : MonoBehaviour
{
    [SerializeField] Transform roadUp;
    [SerializeField] Transform roadUnder;
    [SerializeField] GameObject criminal;
    [SerializeField] GameObject criminalGun;
    [SerializeField] float timeSpawn;
    [SerializeField] float timeDelay1;
    [SerializeField] int maxInTurn;

    public delegate void SpawnCriminalGun();
    public static SpawnCriminalGun spawnCriminalGun;
    Vector3 spawnUp, spawnUnder;
    public void Start()
    {
        float sizeCam = Camera.main.orthographicSize * Camera.main.aspect;
        spawnUp = new Vector3(-sizeCam - 2f, roadUp.position.y, roadUp.position.z);
        spawnUnder = new Vector3(sizeCam + 2f, roadUnder.position.y, roadUnder.position.z);
        StartToSpawn();
    }

    private void OnEnable()
    {
        spawnCriminalGun += StartSpawnCriminalGun;
        GameScene24Manager.ins.endScene += EndScene; 
    }

    void InstantiateCriminal(GameObject typeCriminal, Vector3 posSpawn, float directX)
    {
        GameObject newCrim = Instantiate(typeCriminal, posSpawn, Quaternion.identity);
        newCrim.GetComponent<Criminal_SceneBank>().directX = directX;
        if (posSpawn == spawnUnder)
        {
            newCrim.GetComponent<Criminal_SceneBank>().IncreaseOrderLayer();
        }
    }

    IEnumerator SpawnCriminal1()
    {
        int cnt = 0;
        while (cnt <= maxInTurn)
        {
            cnt++;
            InstantiateCriminal(criminal, spawnUnder, -1);
            InstantiateCriminal(criminal, spawnUp, 1);
            yield return new WaitForSeconds(timeDelay1);
            InstantiateCriminal(criminal, spawnUnder, -1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminal2));
    }

    IEnumerator SpawnCriminal2()
    {
        int cnt = 0;

        while (cnt <= maxInTurn)
        {
            cnt++;
            InstantiateCriminal(criminal, spawnUp, 1);
            InstantiateCriminal(criminal, spawnUnder, -1);
            yield return new WaitForSeconds(timeDelay1);
            InstantiateCriminal(criminal, spawnUp, 1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminal1));

    }

    IEnumerator SpawnCriminalGun1()
    {
        int cnt = 0;
        while (cnt <= maxInTurn)
        {
            cnt++;
            InstantiateCriminal(criminalGun, spawnUp, 1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminalGun2));
    }



    IEnumerator SpawnCriminalGun2()
    {
        int cnt = 0;
        while (cnt <= maxInTurn)
        {
            cnt++;
            InstantiateCriminal(criminalGun, spawnUnder, -1);
            yield return new WaitForSeconds(timeSpawn);
        }
        StartCoroutine(nameof(SpawnCriminalGun1));

    }

    private void StartToSpawn()
    {
        StartCoroutine(nameof(SpawnCriminal1));
    }

    public void StartSpawnCriminalGun()
    {
        StartCoroutine(nameof(SpawnCriminalGun1));
    }

    private void EndScene()
    {
        StopAllCoroutines();
    }
}
