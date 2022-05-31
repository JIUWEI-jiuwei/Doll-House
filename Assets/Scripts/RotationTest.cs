
using UnityEngine;
using UnityEngine.EventSystems;
///<summary>
///
///</summary>
class RotationTest : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private float zAngle = 30f;
    public Vector3 ori;
    public Vector3 fin;
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ori = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        fin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 vS = ori - this.transform.GetChild(0).transform.position;
        Vector3 vT = fin - this.transform.GetChild(0).transform.position;
        this.transform.localRotation = Quaternion.FromToRotation(vS.normalized, vT.normalized);
    }
    public void OnDrag(PointerEventData eventData)
    {


        //transform.RotateAround(this.transform.GetChild(0).transform.position, Vector3.forward, zAngle);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
