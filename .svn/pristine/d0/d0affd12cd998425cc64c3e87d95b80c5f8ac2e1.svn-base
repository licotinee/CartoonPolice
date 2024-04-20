using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWash : MonoBehaviour
{
    [SerializeField] SpriteRenderer waterSpriteCar;
    [SerializeField] Sprite cleanCar;
    [SerializeField] GameObject wheel1;
    [SerializeField] GameObject wheel2;
    [SerializeField] GameObject driverPolice;
    [SerializeField] GameObject spawnVirus;
    [SerializeField] GameObject ListSoapBalls;
    [SerializeField] GameObject dirtImageGO;

    public delegate void ECompleteCleanWater();
    public static event ECompleteCleanWater eCompleteCleanWater;

    private void Awake()
    {
        transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - 12f, transform.position.y, transform.position.z);
        StartCoroutine(StartMoveToThePosWashing());
    }
    private void Start()
    {
        GameScene51Manager.ins.car = this;
    }
    IEnumerator StartMoveToThePosWashing()
    {
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(0, transform.position.y, transform.position.z);

        float speedRotateWheel= 200f;
        while(eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            wheel1.transform.eulerAngles -= new Vector3(0, 0 ,speedRotateWheel * Time.deltaTime);
            wheel2.transform.eulerAngles -= new Vector3(0, 0 ,speedRotateWheel * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        yield return new WaitForSeconds(0.25f);
        driverPolice.SetActive(true);
        yield return new WaitForSeconds(2f);
        ToolManager.ins.StartWaterTap();
        spawnVirus.SetActive(true);
    }

    public void ActiveListSoapBalls()
    {
        ListSoapBalls.SetActive(true);
    }

    public void ActivewaterSpriteCar()
    {
        waterSpriteCar.gameObject.SetActive(true);
    }

    public void ClearDirt()
    {
        dirtImageGO.SetActive(false);
    }

    public void ClearWaterSprite()
    {
        float speed = 0.2f;
        waterSpriteCar.color -= new Color(0, 0, 0, speed * Time.deltaTime);
        if (waterSpriteCar.color.a <= 0)
        {
            eCompleteCleanWater?.Invoke();
            StartCoroutine(StartMoveToEndGame());
        }
    }

    IEnumerator StartMoveToEndGame()
    {
        yield return new WaitForSeconds(1f);
        float eslapsed = 0;
        float seconds = 2f;
        Vector3 start = transform.position;
        Vector3 end = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 12f, transform.position.y, transform.position.z);

        float speedRotateWheel = 200f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            wheel1.transform.eulerAngles -= new Vector3(0, 0, speedRotateWheel * Time.deltaTime);
            wheel2.transform.eulerAngles -= new Vector3(0, 0, speedRotateWheel * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;

        GameScene51Manager.ins.EndScene();
    }
}
