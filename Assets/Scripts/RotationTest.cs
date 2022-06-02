
using UnityEngine;
using UnityEngine.EventSystems;
///<summary>
///��ת���Խű���δ����
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

    Vector2 lastPos;//����ϴ�λ��
    Vector2 currPos;//��굱ǰλ��
    Vector2 offset;//����λ�õ�ƫ��ֵ
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
            //�ж����Ļ������������ĸ�����
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
        {//����Ҳ����
            //ʤ��
            Debug.Log("1");
            
        }
        
    }

    void DoMatch(Vector2 _offset,Transform circle)
    {
        //ˮƽ�ƶ�
        if (Mathf.Abs(_offset.x) > Mathf.Abs(_offset.y))
        {
            if (_offset.x > 0)
            {
                // Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }
            else
            {
                //Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));
            }
        }
        else//��ֱ�ƶ�
        {
            if (_offset.y > 0)
            {
                //Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, zAngle));

            }
            else if(_offset.y < 0)
            {
                //Debug.Log("��");
                circle.Rotate(new Vector3(circle.rotation.x, circle.rotation.y, -zAngle));
            }

        }
    }

}
