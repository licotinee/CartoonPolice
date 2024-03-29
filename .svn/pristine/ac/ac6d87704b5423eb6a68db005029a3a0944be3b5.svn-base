using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircleLight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float rate;
    private bool buttonPressed;
    [SerializeField] Image pyramidLight;
    [SerializeField] Image Light;
    Vector3 normalScale;

    float canvasScale;
    float pyramidLightHeight;
    public float size;
    float maxPos;
    private void Awake()
    {
        size = GetComponent<Image>().sprite.bounds.size.x;
        maxPos = Camera.main.orthographicSize * Camera.main.aspect - size / 2;
        normalScale = transform.localScale;
        pyramidLightHeight = pyramidLight.rectTransform.sizeDelta.y;
        canvasScale = Master.GetTopmostCanvas(this).transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        transform.localScale = new Vector3(normalScale.x * 1.1f, normalScale.y * 1.1f, normalScale.z * 1.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        transform.localScale = normalScale;
    }

    private void FixedUpdate()
    {
        if (GameScene63Manager.ins.isStartScene)
        {
            Vector3 newPos;
            if (buttonPressed && !GameScene63Manager.ins.isEndGame)
            {
                // Move follow mouse
                newPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);

            }
            else if (GameScene63Manager.ins.isEndGame)
            {
                newPos = new Vector3(GameScene63Manager.ins.jangular.transform.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                newPos = transform.position;
            }
            transform.position = Vector3.Lerp(transform.position, newPos, rate);
            //Change rotate lights
            Vector3 direct = transform.position - Light.transform.position;
            float angle = Vector2.Angle(direct, Vector2.right);
            pyramidLight.transform.eulerAngles = new Vector3(0, 0, -angle);
            Light.transform.eulerAngles = new Vector3(0, 0, -angle);
            pyramidLight.rectTransform.sizeDelta = new Vector2(Vector2.Distance(transform.position, pyramidLight.transform.position) / canvasScale, pyramidLightHeight);

            if (transform.position.x >= maxPos)
            {
                transform.position = new Vector3(maxPos, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -maxPos)
            {
                transform.position = new Vector3(-maxPos, transform.position.y, transform.position.z);
            }
        }


    }
}
