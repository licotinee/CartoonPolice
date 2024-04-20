#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

namespace SCN.UnMask
{
    public class UnMaskEditor : UnityEditor.Editor
    {
        private static string UnMaskPrefabPath = "Assets/SCNLib/UnMask/Prefabs/UnMaskEffect.prefab";
        private static string UnMaskWithUIMaskPrefabPath = "Assets/SCNLib/UnMask/Prefabs/UnMaskWithUIMask.prefab";




        [MenuItem("GameObject/UI/UnMask", false, 32)]
        private static void CreateSampleUnMaskUI()
        {
            var asset = AssetDatabase.LoadAssetAtPath(UnMaskPrefabPath, typeof(GameObject));
            var instantiatedPrefab = PrefabUtility.InstantiatePrefab(asset);
            var canvas = FindObjectOfType<Canvas>();
            GameObject obj = instantiatedPrefab as GameObject;
            obj.GetComponent<Transform>().transform.SetParent(canvas.transform);
            obj.GetComponent<Transform>().SetAsLastSibling();
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            Selection.activeObject = obj;
            EditorUtility.SetDirty(obj);
            EditorSceneManager.MarkSceneDirty(((GameObject)instantiatedPrefab).scene);
        }

        [MenuItem("GameObject/UI/UnMask", true, 32)]
        private static bool ValidateUI()
        {
            if (FindObjectOfType<Canvas>())
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        [MenuItem("GameObject/UI/UnMask_WithUIMask", false, 32)]
        private static void CreateSampleUnMaskWithUIMask()
        {
            var asset = AssetDatabase.LoadAssetAtPath(UnMaskWithUIMaskPrefabPath, typeof(GameObject));
            var instantiatedPrefab = PrefabUtility.InstantiatePrefab(asset);
            var canvas = FindObjectOfType<Canvas>();
            GameObject obj = instantiatedPrefab as GameObject;
            obj.GetComponent<Transform>().transform.SetParent(canvas.transform);
            obj.GetComponent<Transform>().SetAsLastSibling();
            Selection.activeObject = obj;
            EditorUtility.SetDirty(obj);
            EditorSceneManager.MarkSceneDirty(((GameObject)instantiatedPrefab).scene);
        }

        [MenuItem("GameObject/UI/UnMask_WithUIMask", true, 32)]
        private static bool ValidateUnMaskWithUIMask()
        {
            if (FindObjectOfType<Canvas>())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
#endif
