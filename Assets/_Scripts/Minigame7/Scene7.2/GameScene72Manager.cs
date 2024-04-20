using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameScene24Manager;

public class GameScene72Manager : MonoBehaviour
{
    public static GameScene72Manager ins;
    [SerializeField] public DogScene72 dog;
    [SerializeField] public int maxPoint;
    [SerializeField] public CriminalScene72 criminal;
    public int curPoint;

    [SerializeField] BarPannelScene72 barPannel;

    public float scaleSpeed;

    public bool isDogAttacking;

    // licotine
    [SerializeField] private GameObject particleSystem;
    [SerializeField] private GameObject endScene;
    [SerializeField] private ShadeBg endShade;
    [SerializeField] private ShadeBg startShade;
    //[SerializeField] private GameObject endShade;

    private void Awake()
    {
        ins = this;
        scaleSpeed = 1.0f;
    }
    private void Start()
    {
        startShade.gameObject.SetActive(true);
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_dog_chase);
    }
    public void UpDatePoint()
    {
        curPoint++;
        barPannel.UpdateBarFill(1.0f * curPoint / maxPoint);
        barPannel.UpdateIcon(1.0f * curPoint / maxPoint);
    }

    public void UpdateScaleSpeed(int curCheckPoint)
    {
        if (curCheckPoint == 1)
        {
            scaleSpeed = 1.5f;
        }

        if (curCheckPoint == 2)
        {
            scaleSpeed = 2f;
        }
    }

    public void AttackTheCriminal(int curCheckPoint)
    {
        if (curCheckPoint < 3)
        {
            StartCoroutine(StartAttack());
        }
        else
        {
            SoundManager.Instance.PlaySFX(SoundTag.Eff_dog_bited);
            StartCoroutine(StartEndScene());
        }
        
    }

    IEnumerator StartAttack()
    {
        dog.StopMove();
        criminal.StopSpawn();
        
        SoundManager.Instance.PlaySFX(SoundTag.Eff_dog_bited);

        Vector3 start, end;
        start = dog.transform.position;
        end = new Vector3(criminal.transform.position.x - 3f, criminal.transform.position.y, dog.transform.position.z);

        float seconds = 0.5f;
        float eslapsed = 0;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            dog.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        dog.transform.position = end;

        isDogAttacking = true;
        dog.Attack();
        criminal.BeAttacked();

        yield return new WaitForSeconds(1f);

        dog.SetAnimRun();
        criminal.SetAnimRun();
        // Move back and reset
        eslapsed = 0;

        start = dog.transform.position;
        end = dog.startPos;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            dog.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        dog.transform.position = end;
        isDogAttacking = false;

        dog.Reset();
        criminal.Reset();
    }

    IEnumerator StartEndScene()
    {
        Handheld.Vibrate();
        SoundManager.Instance.PlaySFX(SoundTag.Eff_enemy_crying_airplane);
        StartCoroutine(MoveBarProgress());
        dog.StopMove();
        criminal.StopSpawn();

        isDogAttacking = true;

        Vector3 start, end;
        start = dog.transform.position;
        end = new Vector3(criminal.transform.position.x - 4f, criminal.transform.position.y, dog.transform.position.z);

        float seconds = 2f;
        float eslapsed = 0;

        float startSize = Camera.main.orthographicSize;
        float endSize = startSize * 3f / 4;

        float maxDist = Vector3.Distance(start, end);
        float curDist;
        float endPosCamX = Vector3.Lerp(end, criminal.transform.position, 0.5f).x;
        float endPosCamY = criminal.transform.position.y + 2f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            dog.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);

            //Camera move
            curDist = Vector3.Distance(dog.transform.position, end);
            Camera.main.orthographicSize = startSize + (1 - curDist / maxDist) * (endSize - startSize);

            float posCamX = (1 - curDist / maxDist) * endPosCamX;
            float posCamY = (1 - curDist / maxDist) * endPosCamY;
            Camera.main.transform.position = new Vector3(posCamX, posCamY, Camera.main.transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        dog.transform.position = end;
        Camera.main.orthographicSize = endSize;

        dog.EndScene();
        criminal.EndScene();

        yield return new WaitForSeconds(2f);
        ActiveEndScene();
    }

    public void ActiveEndScene()
    {
        StartCoroutine(nameof(StartEfectEndScene));
    }

    IEnumerator StartEfectEndScene()
    {
        Vector3 camPosCur = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0f) ;
        particleSystem.transform.position = camPosCur;
        particleSystem.transform.localScale = Vector3.one * 0.8f;
        particleSystem.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundTag.Eff_paper_firework_particle);
        yield return new WaitForSeconds(2.5f);
        endScene.transform.position = camPosCur;
        endScene.transform.localScale = Vector3.one * 0.8f;
        endScene.gameObject.SetActive(true);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_reward_star);
        yield return new WaitForSeconds(4f);

        endShade.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);
        this.CompleteMinigame7();
    }

    IEnumerator MoveBarProgress()
    {
        Vector3 start, end;
        start = barPannel.transform.position;
        end = start - new Vector3(Camera.main.orthographicSize * Camera.main.aspect, 0, 0);

        float seconds = 2f;
        float eslapsed = 0;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            barPannel.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }

    }

    private void CompleteMinigame7()
    {
        SoundManager.Instance.PlayBGM(SoundTag.Bgm_home);
        string curMinigame = PlayerPrefs.GetString("curMinigame");
        LevelManager.ins.UpdateLevel(curMinigame);
        ScenesManager.ins.LoadScene("SceneMenu");
    }
}
