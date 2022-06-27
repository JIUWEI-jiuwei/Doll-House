using UnityEngine.SceneManagement;
using UnityEngine;

///<summary>
///
///</summary>
class PlayerText : MonoBehaviour
{
    private int num = 0;
    private int num1 = 0;
    private bool oneTime = false;
    private GameObject dialog;
    private Transform dialogPos;
    private GameObject player;
    public GameObject dialogPrefab;

    private void Start()
    {
        player = GameObject.Find("playerEnd");
        if (player != null)
        {
            dialogPos = player.transform.GetChild(0);
        }
        InvokeRepeating("MoveOutText", 10f, 9f);
    }
    private void FixedUpdate()
    {
        if (dialog != null && dialogPos != null)
        {
            float zz = 0;
            dialog.transform.position = new Vector3(dialogPos.position.x, dialogPos.position.y, zz);
            dialog.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(dialog.GetComponent<RectTransform>().anchoredPosition3D.x, dialog.GetComponent<RectTransform>().anchoredPosition3D.y,zz);
        }
        if (Input.GetMouseButtonUp(0))
        {

            num++;
            num1++;
        }
        
       /* if (SceneManager.GetActiveScene().name == "EndGame")
        {
            if (num1 == 3 && oneTime == false)
            {
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if (canvas.name == "Canvas")
                    {
                        dialog = Instantiate(dialogPrefab, canvas.transform);
                        dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "墙上的图片可以点击";
                        Invoke("DestroyDialog", 2f);
                    }
                }

            }
        }*/
    }

    private void MoveOutText()
    {
        if (SceneManager.GetActiveScene().name == "DollLayer3")
        {
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if (canvas.name == "Canvas")
                    {
                        dialog = Instantiate(dialogPrefab, canvas.transform);
                        dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "该出去了";
                        Invoke("DestroyDialog", 2f);
                    }
                }            
        }
    }

    private void DestroyDialog()
    {
        Destroy(dialog);
        oneTime = true;
    }
}
