using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsable : MonoBehaviour
{
    [SerializeField] List<Transform> posSpawn;
    [SerializeField] List<Obsacle_Scene5_1> ListObsacles;
    [SerializeField] float timeSpawnObsacle;
    public int cntSpawn;

    private void Start()
    {
        transform.position = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 3f, transform.position.y, transform.position.z);
    }
    
    public void Spawn()
    {
        if (!GameScene15Manager.ins.isStopSpawn)
        {
            StartCoroutine(nameof(StartSpawn));
        }
    }
    IEnumerator StartSpawn()
    {
        int ran;
        float curPosYCriminal;
        while (true)
        {
            yield return new WaitForSeconds(timeSpawnObsacle / GameScene15Manager.ins.level);
            do
            {
                ran = Random.Range(0, posSpawn.Count);
                curPosYCriminal = GameScene15Manager.ins.criminal.newY;
            } while (Mathf.Abs(posSpawn[ran].position.y - curPosYCriminal) <= 0.05f );
            
            Vector3 pos = new Vector3(transform.position.x, posSpawn[ran].position.y, transform.position.z);
            ran = Random.Range(0, ListObsacles.Count);
            Instantiate(ListObsacles[ran], pos, Quaternion.identity);
            cntSpawn++;
        }
    }
    public void StopSpawn()
    {
        StopCoroutine(nameof(StartSpawn));
    }
}
