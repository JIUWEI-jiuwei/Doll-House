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
    }
    private void FixedUpdate()
    {
        if (dialog != null && dialogPos != null)
        {
            dialog.transform.position = dialogPos.position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            num++;
            num1++;
        }
        if(SceneManager.GetActiveScene().name== "DollLayer3")
        {
            if (num % 2 == 0 && num > 0)
            {
                foreach (Canvas canvas in FindObjectsOfType<Canvas>())
                {
                    if (canvas.name == "UpperCanvas")
                    {
                        dialog = Instantiate(dialogPrefab, canvas.transform);
                        dialog.transform.GetChild(0).GetComponent<ShrinkText>().text = "该出去了";
                        Invoke("DestroyDialog", 2f);
                    }
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "EndGame")
        {
            if (num1 == 3&&oneTime==false)
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
        }
    }
    private void DestroyDialog()
    {
        Destroy(dialog);
        oneTime = true;
    }
}
