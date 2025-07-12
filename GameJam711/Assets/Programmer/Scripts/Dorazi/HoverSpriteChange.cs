using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverSpriteChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image targetImage;         // 바꿀 이미지 대상
    public Sprite originalSprite;     // 원래 이미지
    public Sprite hoverSprite;        // 마우스 올렸을 때의 이미지

    // 마우스를 올렸을 때 실행
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null && hoverSprite != null)
        {
            targetImage.sprite = hoverSprite;
        }
    }

    // 마우스를 뗐을 때 실행
    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetImage != null && originalSprite != null)
        {
            targetImage.sprite = originalSprite;
        }
    }
}
