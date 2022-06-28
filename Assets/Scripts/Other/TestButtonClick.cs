using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestButtonClick : MonoBehaviour
{
    private Button m_TestBtn;
    private Image m_TestImage;

    private void Awake()
    {
        m_TestBtn = this.transform.GetComponent<Button>();
        m_TestImage = this.transform.GetComponent<Image>();

        m_TestBtn.onClick.AddListener(ButtonClick);
        m_TestImage.alphaHitTestMinimumThreshold = 0.1f;
    }

    private void ButtonClick()
    {
        //Debug.LogError("µã»÷TestBtn");
    }
}
