
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PolygonImage : Image, IPointerEnterHandler, IPointerExitHandler
{

    private PolygonCollider2D m_PolygonCollider2D;


    public PolygonCollider2D PolygonCollider2D
    {
        get
        {
            return gameObject.GetOrAddComponent<PolygonCollider2D>();

        }

        private set { }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }



    public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        Vector3 point;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPoint, eventCamera, out point);

        return PolygonCollider2D.OverlapPoint(point);
    }
}

public static class MonoExtend
{
    public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {

        if (obj.GetComponent<T>() == null)
        {
            return obj.AddComponent<T>();
        }

        return obj.GetComponent<T>();
    }
}