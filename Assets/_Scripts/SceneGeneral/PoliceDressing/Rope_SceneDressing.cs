using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_SceneDressing : MonoBehaviour
{
    private Vector3 belowPos;
    private Vector3 abovePos;
    [SerializeField] List<DevicePolice_SceneDressing> ListDevices;
    public bool sideRope;  // true -> Right ; false -> Left
    [SerializeField] float timeMove;

    public delegate void DeviceOnClick(bool sideDevide);
    public static DeviceOnClick deviceOnClick;
    public delegate void DeviceOffClick(bool sideDevide);
    public static DeviceOffClick deviceOffClick;
    public delegate void DeviceTrueDrop(bool sideDevide);
    public static DeviceTrueDrop deviceTrueDrop;

    private void Awake()
    {
        belowPos = transform.position;
        abovePos = belowPos + new Vector3(0, Camera.main.orthographicSize, 0);
        transform.position = abovePos;
        SetUpDevices();
    }

    private void OnEnable()
    {
        deviceOnClick += MoveUp;
        deviceOffClick += MoveDown;
        deviceTrueDrop += RemoveDevice;
    }

    private void OnDestroy()
    {
        deviceOnClick -= MoveUp;
        deviceOffClick -= MoveDown;
        deviceTrueDrop -= RemoveDevice;
    }

    private void SetUpDevices()
    {
        foreach (DevicePolice_SceneDressing device in ListDevices)
        {
            device.belowPos = belowPos;
            device.abovePos = abovePos;
            device.sideDevice = sideRope;
            device.timeMove = timeMove;
        }
    }

    public void StartTurn()
    {
        ListDevices[0].gameObject.SetActive(true);
        StopAllCoroutines();
        IEnumerator newCoroutine = StartMove(transform.position, belowPos);
        StartCoroutine(newCoroutine);
    }

    public void MoveDown(bool sideDevice)
    {
        if (sideRope == sideDevice)
        {
            StopAllCoroutines();
            IEnumerator newCoroutine = StartMove(transform.position, belowPos);
            StartCoroutine(newCoroutine);
        }

    }

    private void MoveUp(bool sideDevice)
    {
        if (sideRope == sideDevice)
        {
            StopAllCoroutines();
            IEnumerator newCoroutine = StartMove(transform.position, abovePos);
            StartCoroutine(newCoroutine);
        }
    }

    IEnumerator StartMove(Vector3 start, Vector3 end)
    {
        float eslapsed = 0;
        float seconds = timeMove;
        transform.position = start;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    private void RemoveDevice(bool sideDevice)
    {
        if (sideRope == sideDevice)
        {
            ListDevices.RemoveAt(0);
            RopeManager_SceneDressing.updateEquipped?.Invoke();
        }
    }
}
