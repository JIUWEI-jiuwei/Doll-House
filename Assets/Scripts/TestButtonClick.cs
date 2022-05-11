using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button不规则按钮点击透明区域不响应
/// </summary>
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
        //Debug.LogError("点击TestBtn");
    }
}
