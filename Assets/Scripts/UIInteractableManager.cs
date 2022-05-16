using UnityEngine;

///<summary>
///
///</summary>
class UIInteractableManager : MonoBehaviour
{
    private GameObject panel;
    private void Awake()
    {
        
    }
    private void Start()
    {
        //FindGameObjectWithTag����Ҫactive����������ҵ����������ҵ�����SetActive(false)
        panel = GameObject.FindGameObjectWithTag("panel");
        panel.SetActive(false);
    }
    /// <summary>
    /// ���������֮��(��ť�����ƺ�resources�������Ʒ������һ��)
    /// </summary>
    public void MouseDownButton()
    {
        Destroy(this.gameObject);
        panel.SetActive(true);
        if (Resources.Load(this.gameObject.name) != null)
        {
            //ʵ����resources����ġ�Ԥ���塱��Instantiateʵ�����ı�����Ԥ����
            GameObject a = Instantiate(Resources.Load(this.gameObject.name)) as GameObject;
            a.transform.SetParent(panel.transform);
        }
        else
        {
            Debug.Log("null");
        }
    }
}
