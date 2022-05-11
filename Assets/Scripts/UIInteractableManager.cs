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
        panel = GameObject.FindGameObjectWithTag("panel");
        panel.SetActive(false);
    }
    public void MouseDownButton()
    {
        Destroy(this.gameObject);
        panel.SetActive(true);
        if (Resources.Load(this.gameObject.name) != null)
        {
            GameObject a = Instantiate(Resources.Load(this.gameObject.name)) as GameObject;
            a.transform.SetParent(panel.transform);
        }
        else
        {
            Debug.Log("null");
        }
    }
}
