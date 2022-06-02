
using UnityEngine;
using UnityEngine.EventSystems;
///<summary>
///旋转测试脚本（未启用
///</summary>
class RotationTest : MonoBehaviour
{

    /* public Vector3 ori;
    public Vector3 fin;
    public bool isDown = false;

    private void FixedUpdate()
     {
         if (Input.GetMouseButtonDown(0))
         {
             ori = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             isDown = true;
         }
         fin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector3 vS = ori - this.transform.GetChild(0).transform.position;
         Vector3 vT = fin - this.transform.GetChild(0).transform.position;
         //this.transform.localRotation = Quaternion.FromToRotation(vS.normalized, vT.normalized);
         float a = this.transform.position.z + Vector3.Angle(vS, vT);
         //this.transform.rotation = new Vector3(this.transform.position.x, this.transform.position.y, a);
         if (isDown)
         {
             this.transform.Rotate(new Vector3(this.transform.position.x, this.transform.position.y, zAngle));
             isDown = false;
         }


     }*/

    Vector2 lastPos;//鼠标上次位置
    Vector2 currPos;//鼠标当前位置
    Vector2 offset;//两次位置的偏移值
    private float zAngle = 30f;
    public Transform circle1;
    public Transform circle2;
    public Transform circle3;


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            currPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = currPos - lastPos;
            //判定鼠标的滑动区域在是哪个密码
            if (lastPos.x > -8 && lastPos.x < -4.5 && lastPos.y > -0.5 && lastPos.y < 2.5)
            {
                DoMatch(offset, circle1);
            }
            else if (lastPos.x > -3 && lastPos.x < 0 && lastPos.y > -0.5 && lastPos.y < 2.5)
            {
                DoMatch(offset, circle2);
            }
            else if (lastPos.x > 2 && lastPos.x < 5 && lastPos.y > -0.5 && lastPos.y < 2.5)
            {
                DoMatch(offset, circle3);
            }

        }
        if (circle1.eulerAngles.z%360 ==0 && circle2.eulerAngles.z%360 ==330&& circle3.eulerAngles.z%360 ==270)
        {//负数也适用
            //胜利
            Debug.Log("1");
            
        }
        
    }

    void DoMatch(Vector2 _offset,Transform circle)
    {
        //水平移动
        if (Mathf.Abs(_offset.x) > Mathf.Abs(_offset.y))
        {
            if (_offset.x > 0)
            {
                // Debug.Log("右");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }
            else
            {
                //Debug.Log("左");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));
            }
        }
        else//垂直移动
        {
            if (_offset.y > 0)
            {
                //Debug.Log("上");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));

            }
            else if(_offset.y < 0)
            {
                //Debug.Log("下");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }

        }
    }

}
