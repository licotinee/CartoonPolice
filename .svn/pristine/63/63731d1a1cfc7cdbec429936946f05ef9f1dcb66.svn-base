using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay_Scene4_1_Manager : MonoBehaviour
{
    public static GamePlay_Scene4_1_Manager ins;
    int cntTrueBoPhan;
    [SerializeField] GameObject than;
    [SerializeField] GameObject bong;
    [SerializeField] GameObject nhapNhay;
    [SerializeField] List<BoPhanGhepHinh> ListBoPhan;
    [SerializeField] GameObject blackBg;
    [SerializeField] GameObject oldBoard;
    [SerializeField] ElectronicBoard NewBoard;
    [SerializeField] Police_Scene4_1 police;
    [SerializeField] Criminal_Scene4_1 criminal;
    private void Start()
    {
        ins = this;
        StartCoroutine(StartGame());
    }

    public void UpdateCntTrueBoPhan()
    {
        cntTrueBoPhan++;
        if(cntTrueBoPhan == 3)
        {
            StartCoroutine(StartNhapNhayThan());
        }
    }

    IEnumerator StartNhapNhayThan()
    {
        than.GetComponent<ThanSprite>().NhapNhay();
        yield return new WaitForSeconds(1.5f);
        Destroy(oldBoard);
        NewBoard.gameObject.SetActive(true);
        criminal.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        NewBoard.TurnOnLight();
        police.MoveUp();
        criminal.Scare();
        yield return new WaitForSeconds(3f);
        GameScene4Manager.ins.EndScene();
    }

    IEnumerator StartGame()
    {
        float sizeCam = Camera.main.orthographicSize * Camera.main.aspect;
        int tmp = ListBoPhan.Count / 2;
        for (int i = 0; i < ListBoPhan.Count; ++i)
        {
            ListBoPhan[i].transform.position = new Vector3((i-tmp) * (2f / 3) * sizeCam, 0, 0);
        }
        yield return new WaitForSeconds(2f);
        blackBg.gameObject.SetActive(false);
        for (int i = 0; i < ListBoPhan.Count; ++i)
        {
            ListBoPhan[i].MoveToStartPos(0.3f);
        }
        yield return new WaitForSeconds(0.3f);
        than.SetActive(true);
        bong.SetActive(true);
        nhapNhay.SetActive(true);
        
    }
}
