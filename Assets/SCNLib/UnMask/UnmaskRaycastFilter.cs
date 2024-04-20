using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Unmask/UnmaskRaycastFilter", 2)]
public class UnmaskRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
{
    //Unmask muốn sử dụng
    public Transform UnmaskTarget;

    //Xác định khu vực bị raycast bỏ qua hoặc không bỏ qua
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        //Nếu unmask hoặc bản thân bị tắt thì mặc định trả về true
        if (!isActiveAndEnabled || !UnmaskTarget.gameObject.activeInHierarchy)
        {
            Debug.Log(true);
            return false;
        }

        // check inside
        if (eventCamera)
        {
            //Nếu point nằm ngoài khu vực của unmask thì trả về true (raycast sẽ bị chặn) , ngược lại sẽ không bị chặn (xuyên qua khu vực của unmask)
            Debug.Log(!RectTransformUtility.RectangleContainsScreenPoint((UnmaskTarget.transform as RectTransform), sp, eventCamera));
            return !RectTransformUtility.RectangleContainsScreenPoint((UnmaskTarget.transform as RectTransform), sp, eventCamera);

        }
        else
        {
            Debug.Log(!RectTransformUtility.RectangleContainsScreenPoint((UnmaskTarget.transform as RectTransform), sp, eventCamera));
            return !RectTransformUtility.RectangleContainsScreenPoint((UnmaskTarget.transform as RectTransform), sp);
        }
    }
}