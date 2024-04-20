using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneIntro5_1 
{
    public class Store : MonoBehaviour
    {
        [SerializeField] List<GameObject> doors;
        
        public delegate void EDoor();
        public static EDoor openDoor;
        public static EDoor closeDoor;

        private void OnEnable()
        {
            openDoor += OpenDoor;
            closeDoor += CloseDoor;
        }

        private void OnDestroy()
        {
            openDoor -= OpenDoor;
            closeDoor -= CloseDoor;
        }

        private void OpenDoor()
        {
            StartCoroutine(StoreStartShrug());
            foreach (GameObject door in doors)
            {
                door.transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }

        IEnumerator StoreStartShrug()
        {
            float start = transform.localScale.y;
            float end = 1.2f * start;
            float eslapsed = 0;
            float seconds = 0.25f;
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.localScale = new Vector3(transform.localScale.x, start + (end - start) * eslapsed / seconds, transform.localScale.z);
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = new Vector3(transform.localScale.x, end, transform.localScale.z);

            eslapsed = 0;
            end = start;
            start = transform.localScale.y;
            while (eslapsed <= seconds)
            {
                eslapsed += Time.deltaTime;
                transform.localScale = new Vector3(transform.localScale.x, start + (end - start) * eslapsed / seconds, transform.localScale.z);
                yield return new WaitForEndOfFrame();
            }
            transform.localScale = new Vector3(transform.localScale.x, end, transform.localScale.z);
        }


        private void CloseDoor()
        {
            foreach (GameObject door in doors)
            {
                door.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }

    }
}

