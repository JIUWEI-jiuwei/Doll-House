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
    /// <summary>种子的SpriteState</summary>
    private SpriteState spriteStatus;

    private void Start()
    {
        seed = this.GetComponent<Animator>();
        //创建一个新的SpriteState（唯一可行的修改SpriteState的方法）
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
        //种子+绿盆+水=烟草；种子+红盆+狞猫的唾液=毒草；其余任何方式都只会种出杂草
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
    /// 切换按钮的sprite图片
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
