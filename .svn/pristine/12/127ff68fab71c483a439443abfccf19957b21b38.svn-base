using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPhoto_Scene6_8 : MonoBehaviour
{
    [SerializeField] List<GameObject> Photos;
    [SerializeField] List<Transform> PosInBoard;
    int index = 0;

    public void GetPhoto(float seconds)
    {
        Photos[index].SetActive(true);
        StartCoroutine(MoveToBoard(Photos[index], seconds));
    }

    IEnumerator MoveToBoard(GameObject photo, float seconds)
    {
        float eslapsed = 0;
        Vector3 start = photo.transform.position;
        Vector3 end = PosInBoard[index].position;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            photo.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        photo.transform.position = end;

        index++;
        if (index == 1)
        {
            GameScene86Manager.ins.criminal.TurnLeft();
        }
        if (index == Photos.Count)
        {
            GameScene86Manager.ins.criminal.Scare();
            GameScene86Manager.ins.EndGame();
        }

    }
}
