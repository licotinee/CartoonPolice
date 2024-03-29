using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
namespace SceneIntro5_1
{
    public class Criminal : MonoBehaviour
    {
        [SerializeField] SkeletonAnimation skeleton;

        [SerializeField] Transform posOnRoad;

        public delegate void CompleteRun();
        public static event CompleteRun completeRun;

        private void Start()
        {
            StartCoroutine(StartMoveToPosOnRoad());
        }

        IEnumerator StartMoveToPosOnRoad()
        {
            yield return new WaitForSeconds(1f);
            Store.openDoor?.Invoke();
            Vector3 start = transform.position;
            Vector3 end = posOnRoad.transform.position;
            skeleton.GetComponent<MeshRenderer>().sortingOrder = 4;
            float eslapsed = 0;
            float seconds = 0.5f;
            skeleton.AnimationState.SetAnimation(0, "Run_c2", true);
            while(eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = end;
            Store.closeDoor?.Invoke();

            start = transform.position;
            end = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + 2f, transform.position.y, transform.position.z);
            eslapsed = 0;
            seconds = 1f;
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
                yield return new WaitForEndOfFrame();
            }
            transform.position = end;
            completeRun?.Invoke();
            gameObject.SetActive(false);
        }

    }
}

