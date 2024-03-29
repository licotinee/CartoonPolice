using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHead : MonoBehaviour
{
    bool isbeingHeld;
    private Vector3 offset;
    Vector3 startPos;
    [SerializeField] ParticleSystem particleSystem;
    bool isStartPartical;
    [SerializeField] Transform PosRaycastLeft;
    [SerializeField] Transform PosRaycastRight;
    [SerializeField] Transform PosRaycastCenter;
    RaycastHit2D[] hitLeft;
    RaycastHit2D[] hitRight;
    RaycastHit2D[] hitCenter;
    public LayerMask layer;
    float distRaycast;
    [SerializeField] float speedRay;
    List<GameObject> Hits;

    private bool isEnd;

    private void Awake()
    {
        Hits = new List<GameObject>();
        startPos = transform.position;
    }

    private void OnEnable()
    {
        SoapBallManager.eEndShower += EndShower;
        StartCoroutine(MoveToStartPos());
    }

    private void OnDestroy()
    {
        SoapBallManager.eEndShower -= EndShower;
    }

    IEnumerator MoveToStartPos()
    {
        Vector3 start = new Vector3(transform.position.x, Camera.main.orthographicSize + 3f, transform.position.z);
        Vector3 end = new Vector3(transform.position.x, Camera.main.orthographicSize - 0.75f, transform.position.z);
        float eslapsed = 0;
        float seconds = 0.5f;
        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
        startPos = transform.position;

    }

    private void Update()
    {
        if (isbeingHeld && ToolManager.ins.isStartTurn)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            if (distRaycast <= 10f)
            {
                distRaycast += speedRay * Time.deltaTime;
            }
            hitLeft = Physics2D.RaycastAll(PosRaycastLeft.position, Vector2.down, distRaycast, layer);
            hitRight = Physics2D.RaycastAll(PosRaycastRight.position, Vector2.down, distRaycast, layer);
            hitCenter = Physics2D.RaycastAll(PosRaycastCenter.position, Vector2.down, distRaycast, layer);
            if (hitLeft != null || hitRight != null || hitCenter != null)
            {
                // Get coliders raycast hit
                foreach (RaycastHit2D soapBall in hitLeft)
                {
                    if(!Hits.Contains(soapBall.collider.gameObject))
                    {
                        Hits.Add(soapBall.collider.gameObject);
                    }
                }
                foreach (RaycastHit2D soapBall in hitRight)
                {
                    if (!Hits.Contains(soapBall.collider.gameObject))
                    {
                        Hits.Add(soapBall.collider.gameObject);
                    }
                }

                foreach (RaycastHit2D soapBall in hitCenter)
                {
                    if (!Hits.Contains(soapBall.collider.gameObject))
                    {
                        Hits.Add(soapBall.collider.gameObject);
                    }
                }

                SoapBallManager.eCleanSoapBall?.Invoke(Hits);
                Hits.Clear();
            }

        }
    }


    private void OnMouseDown()
    {
        isbeingHeld = true;
        distRaycast = 0;    
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!isStartPartical)
        {
            particleSystem.Play();
        }

    }

    private void OnMouseUp()
    {
        isbeingHeld = false;
        if (!isEnd)
        {
            StartCoroutine(StartToMoveBack());
        }
        particleSystem.Stop();
    }

    IEnumerator StartToMoveBack()
    {
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;

    }   

    private void EndShower()
    {
        isEnd = true;
    }
}
