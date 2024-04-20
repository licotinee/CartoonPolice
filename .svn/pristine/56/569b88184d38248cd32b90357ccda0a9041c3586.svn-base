using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScene71Manager : MonoBehaviour
{
    public static GameScene71Manager ins;
    [SerializeField] List<TurnClickManager> ListTurns;
    int completeTurn;
    int curTurn;
    public TurnClickManager curTurnClick;

    public bool isFindingBanned;
    [SerializeField] public TrueTickMinigame7 trueTick;


    Vector3 startDog;
    [SerializeField] Dog dog;
    [SerializeField] WolfooMinigame7 wolfoo;
    public bool isEndgame;
    private void Awake()
    {
        startDog = dog.transform.position;
        ins = this;
        StartCoroutine(nameof(StartIdle));
    }

    public void StartTurn(GameObject suitcase)
    {
        StopAllCoroutines();
        StartCoroutine(nameof(MoveToSuitcase), suitcase);
    }

    IEnumerator MoveToSuitcase(GameObject suitcase)
    {
        // enable turn
        isFindingBanned = true;
        curTurn = Random.Range(0, ListTurns.Count);
        curTurnClick = ListTurns[curTurn];

        //dog.Reset();
        dog.SetAnimationState("Run", true);
        //wolfoo.Reset();
        wolfoo.SetAnimationState("Idle", true);

        Vector3 start = dog.transform.position;
        Vector3 end = new Vector3(suitcase.transform.position.x, dog.transform.position.y, dog.transform.position.z);

        float eslapsed = 0;
        float seconds = 0.75f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            dog.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        dog.transform.position = end;
        //dog.Reset();
        dog.SetAnimationState("Sit", true);

        yield return new WaitForSeconds(0.25f);
        curTurnClick.gameObject.SetActive(true);
    }

    public void UpdateTurn()
    {
        completeTurn++;
        curTurnClick.gameObject.SetActive(false);
        ListTurns.RemoveAt(curTurn);

        isFindingBanned = false;
        if (completeTurn  == 3)
        {
            EndScene();
        }
        else
        {
            CompleteTurn();
        }
    }


    IEnumerator StartIdle()
    {
        while (true)
        {
            //dog.Reset();
            //wolfoo.Reset();

            dog.SetAnimationState("Idle", true);
            wolfoo.SetAnimationState("Idle", true);

            yield return new WaitForSeconds(2f);
            dog.SetAnimationState("Bark", true);

            yield return new WaitForSeconds(1.6f);
            dog.SetAnimationState("Idle", true);

            yield return new WaitForSeconds(1f);
            wolfoo.SetAnimationState("Order_1", true);
            yield return new WaitForSeconds(1.5f);
        }

    }

    public void Smile()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(StartSmile));
    }

    IEnumerator StartSmile()
    {
        //dog.Reset();
        //wolfoo.Reset();

        dog.SetAnimationState("Happy3", true);
        wolfoo.SetAnimationState("Idle_Laugh", true);
        yield return new WaitForSeconds(1.3f);

        StartCoroutine(nameof(StartIdle));
    }

    IEnumerator StartCompleteTurn()
    {
        dog.transform.position = startDog;
        //dog.Reset();
        //wolfoo.Reset();

        dog.SetAnimationState("Jump", true);
        wolfoo.SetAnimationState("Yay_yay", true);

        yield return new WaitForSeconds(2f);

        StartCoroutine(nameof(StartIdle));
    }

    public void CompleteTurn()
    {
        StartCoroutine(nameof(StartCompleteTurn));
    }


    public void EndScene()
    {   
        StartCoroutine(StartEndScene());
    }

    IEnumerator StartEndScene()
    {
        isEndgame = true;
        dog.Reset();
        wolfoo.Reset();
        dog.transform.position = new Vector3(Camera.main.transform.position.x - 0.75f, dog.transform.position.y, dog.transform.position.z);
        wolfoo.transform.position = new Vector3(Camera.main.transform.position.x + 0.75f, wolfoo.transform.position.y, wolfoo.transform.position.z);

        dog.SetAnimationState("Jump", true);
        wolfoo.SetAnimationState("Cheer", true);
        yield return new WaitForSeconds(2f);
        LoadNewScene();
    }
    private void LoadNewScene()
    {
        string newScene = PlayerPrefs.GetString("curMinigame");
        ScenesManager.ins.LoadScene(newScene + ".2");
    }
}
