using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsacle_Scene3_4 : Singleton<SpawnObsacle_Scene3_4>
{
    
    [SerializeField] List<GameObject> ListObsacle;
    [SerializeField] float timeDelayToStartSpawn;
    [SerializeField] float timeDelaySpawn;
    [SerializeField] List<Transform> posYSpawn;
    private void Awake()
    {
        base.Awake();   
    }
    private void Start()
    {
        if (GameScene43Manager.ins.isTutorial) return;
        StartCoroutine(nameof(StartSpawn));
        
    }

    public void StartSpawnObsacle()
    {
        StartCoroutine(nameof(StartSpawn));
    }
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
    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(timeDelayToStartSpawn);
        int ranPosY;
        int ranObsacle;
        Vector3 posSpawn;
        while (true)
        {
            ranPosY = Random.Range(0, posYSpawn.Count);
            posSpawn = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 3f, posYSpawn[ranPosY].position.y, transform.position.z);
            ranObsacle = Random.Range(0, ListObsacle.Count);
            Debug.LogError("spawn obsable");
            Instantiate(ListObsacle[ranObsacle], posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(timeDelaySpawn);
        }
    }

    protected void EndGame()
    {
        StopCoroutine(nameof(StartSpawn));
    }
}
