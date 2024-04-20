using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneIntro5_1
{
    public class Police : MonoBehaviour
    {
        [SerializeField] SkeletonAnimation skeleton;
        [SerializeField] Transform posOnRoad;

        private void OnEnable()
        {
            Criminal.completeRun += Chase;
        }
        private void OnDestroy()
        {
            Criminal.completeRun -= Chase;
        }
        private void Chase()
        {
            StartCoroutine(StartMoveToPosOnRoad());
        }

        IEnumerator StartMoveToPosOnRoad()
        {
            yield return new WaitForSeconds(0.5f);
            Store.openDoor?.Invoke();
            Vector3 start = transform.position;
            Vector3 end = posOnRoad.transform.position;
            skeleton.GetComponent<MeshRenderer>().sortingOrder = 4;
            float eslapsed = 0;
            float seconds = 0.5f;
            skeleton.AnimationState.SetAnimation(0, "Run_Ninja", true);
            while (eslapsed <= seconds)
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
            GameSceneManager.ins.EndScene();
            gameObject.SetActive(false);
        }
    }
}

