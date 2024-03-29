using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ListPhoto_Scene6_8 : MonoBehaviour
{
    [SerializeField] List<GameObject> Photos ;
    [SerializeField] List<Transform> PosInBoard;
    [SerializeField] List<Sprite> listPhoto0; // janguar
    [SerializeField] List<Sprite> listPhoto1; // Rhino
    [SerializeField] List<Sprite> listPhoto2; // fox
    
    int index = 0;

    private void Start()
    {
        int curLevelScene8 = PlayerPrefs.GetInt("LevelScene8", 0) % 3;
        switch (curLevelScene8)
        {
            case 0:
                Photos[0].GetComponent<SpriteRenderer>().sprite = listPhoto0[0];
                Photos[1].GetComponent<SpriteRenderer>().sprite = listPhoto0[1];
                break;
            case 1:
                Photos[0].GetComponent<SpriteRenderer>().sprite = listPhoto1[0];
                Photos[1].GetComponent<SpriteRenderer>().sprite = listPhoto1[1];
                break;
            case 2:
                Photos[0].GetComponent<SpriteRenderer>().sprite = listPhoto2[0];
                Photos[1].GetComponent<SpriteRenderer>().sprite = listPhoto2[1];
                break;

            
        }
    }

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
