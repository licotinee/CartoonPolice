using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSuitcase : MonoBehaviour
{
    [SerializeField] List<Sprite> Sprites;
    [SerializeField] Suitcase suitcase;
    [SerializeField] float timeSpawn;
    float eslapsed;
    float extras;
    int cnt;

    private void Start()
    {
        StartCoroutine(nameof(StartSpawn));
    }
    IEnumerator StartSpawn()
    {
        while (true)
        {
            if (!GameScene71Manager.ins.isFindingBanned)
            {
                extras = Time.deltaTime;
            }
            else
            {
                extras = 0;
            }
            eslapsed += extras;
            if (eslapsed >= timeSpawn)
            {
                Suitcase newSuit = Instantiate(suitcase, transform.position, Quaternion.identity);
                newSuit.SetUp(Sprites[cnt % Sprites.Count], (cnt % 4 == 0 && cnt > 0));
                cnt++;
                eslapsed = 0;
                //Random.RandomRange(3,6)
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
