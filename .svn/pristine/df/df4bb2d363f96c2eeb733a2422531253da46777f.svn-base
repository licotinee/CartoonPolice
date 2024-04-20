using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevicePolice_SceneDressing : MonoBehaviour
{
    private Vector3 scaleNormal;
    public Vector3 belowPos;
    public Vector3 abovePos;
    public bool sideDevice;
    public float timeMove;

    bool isbeingHeld = false;
    private Vector3 offset;
    private bool isCanDrag;
    Police_SceneDressing police;


    private void Start()
    {
        isCanDrag = true;
        scaleNormal = transform.localScale;
    }
    private void Update()
    {
        if (isbeingHeld)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    private void OnMouseDown()
    {
        if (isCanDrag)
        {
            if (isbeingHeld != true)
            {
                Rope_SceneDressing.deviceOnClick?.Invoke(sideDevice);
            }
            transform.SetParent(null);
            isbeingHeld = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localScale = new Vector3(scaleNormal.x * 1.2f, scaleNormal.y * 1.2f, scaleNormal.z * 1.2f);
        }

    }

    public void OnMouseUp()
    {
        isCanDrag = false;
        isbeingHeld = false;
        bool isTrueDrop = false;
        if (police != null)
        {
            if (!police.isEquipped)
            {
                isTrueDrop = true;
                police.EquipTheDevice();
                Rope_SceneDressing.deviceTrueDrop?.Invoke(sideDevice);
                Destroy(gameObject);    
            }
        }

        if (!isTrueDrop)
        {
            Rope_SceneDressing.deviceOffClick?.Invoke(sideDevice);
            StopCoroutine(nameof(StartToMoveBack));
            StartCoroutine(nameof(StartToMoveBack));
            isCanDrag = true;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            police = collision.gameObject.GetComponent<Police_SceneDressing>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            police = null;
        }
    }

    IEnumerator StartToMoveBack()
    {
        transform.localScale = scaleNormal;

        float elapsedTime = 0;
        float seconds = timeMove;
        Vector3 start = transform.position;
        Vector3 end = belowPos;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(start, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        transform.SetParent(transform.parent, true);
    }
}
