using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
class Seed : MonoBehaviour, IPointerClickHandler
{
    private Animator seed;
    public bool isWater=false;
    public bool isTuoYe=false;
    /// <summary>���ӵ�SpriteState</summary>
    private SpriteState spriteStatus;

    private void Start()
    {
        seed = this.GetComponent<Animator>();
        //����һ���µ�SpriteState��Ψһ���е��޸�SpriteState�ķ�����
        spriteStatus = new SpriteState();
    }
    private void FixedUpdate()
    {
        if (seed.GetCurrentAnimatorStateInfo(0).IsName("seedstop"))
        {
            SwapSprite();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //����+����+ˮ=�̲ݣ�����+����+��è����Һ=���ݣ������κη�ʽ��ֻ���ֳ��Ӳ�
        if (seed.GetCurrentAnimatorStateInfo(0).IsName("seedstop"))
        {
            Destroy(this.gameObject);
            if (isWater == true&& this.transform.parent.name == "green")
            {                
                ItemPanelClick.ChangeItemPanel("yancao");
            }
            else if(isTuoYe== true && this.transform.parent.name == "red")
            {
                ItemPanelClick.ChangeItemPanel("ducao");
            }
            else
            {
                ItemPanelClick.ChangeItemPanel("zacao");
            }
        }
    }
    /// <summary>
    /// �л���ť��spriteͼƬ
    /// </summary>
    private void SwapSprite()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("seedstop");
        spriteStatus.highlightedSprite = Resources.Load<Sprite>("seedstop");
        spriteStatus.pressedSprite = Resources.Load<Sprite>("seedstop");
        spriteStatus.selectedSprite = Resources.Load<Sprite>("seedstop");
        this.GetComponent<Button>().spriteState = spriteStatus;
    }
}
