using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
public class GameScene63Manager : MonoBehaviour
{
    public static GameScene63Manager ins;
    [SerializeField] Image helicopter;
    [SerializeField] public Jangular jangular;
    [SerializeField] Transform startPosHeli;
    [SerializeField] Transform startPosJangular;
    [SerializeField] SkeletonGraphic policeCar;
    public bool isStartScene;

    public bool isEndGame;
    [SerializeField] public float maxTime;
    void Start()
    {
        ins = this;
        StartCoroutine(nameof(StartScene));
    }

    IEnumerator StartScene()
    {
        float lengthScreen = Camera.main.orthographicSize * Camera.main.aspect * 2;
        helicopter.transform.position = new Vector3(startPosHeli.position.x - lengthScreen, helicopter.transform.position.y, helicopter.transform.position.z);
        jangular.transform.position = new Vector3(startPosJangular.position.x - lengthScreen, jangular.transform.position.y, jangular.transform.position.z);

        Vector3 start, end;
        float eslapsed, seconds;

        // jangular move
        // heli Move
        start = jangular.transform.position;
        end = startPosJangular.position;
        eslapsed = 0;
        seconds = 2f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            jangular.transform.position = Vector2.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }



        // heli Move
        start = helicopter.transform.position;
        end = startPosHeli.position;
        eslapsed = 0;
        seconds = 1f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            helicopter.transform.position = Vector2.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }

        //Jangular run Away light and StartScene
        start = jangular.transform.position;
        end = new Vector3(-jangular.lengthRoad, jangular.transform.position.y, jangular.transform.position.z);
        eslapsed = 0;
        seconds = 1f;

        jangular.skeleton.AnimationState.SetAnimation(1, "Angry", true);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            jangular.transform.position = Vector2.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        jangular.skeleton.AnimationState.SetAnimation(1, "Idle", true);
        jangular.progressBar.gameObject.SetActive(true);
        isStartScene = true;

    }

    public void EndGame()
    {
        StartCoroutine(nameof(StartEndScene));
    }

    IEnumerator StartEndScene()
    {
        isEndGame = true;
        jangular.EndScene();

        //
        policeCar.gameObject.SetActive(true);
        float eslapsed = 0;
        float seconds = 1;
        Vector3 start = policeCar.transform.position;
        Vector3 end = jangular.transform.position + new Vector3(5f, 0, 0);
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            policeCar.transform.position = Vector2.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        jangular.skeleton.AnimationState.SetEmptyAnimations(0);
        //jangular.skeleton.AnimationState.SetAnimation(0, "Sad", true);
        jangular.skeleton.AnimationState.SetAnimation(0, "Run_Bike_sad", true);

        policeCar.AnimationState.ClearTrack(0);
        policeCar.Skeleton.SetToSetupPose();
        policeCar.AnimationState.SetAnimation(0, "Cheer", true);

        yield return new WaitForSeconds(2f);
        CompleteMinigame6();    
    }

    private void CompleteMinigame6()
    {
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        //ScenesManager.ins.LoadScene("SceneMenu");
        ScenesManager.ins.LoadScene("Scene6.4");
    }

}
