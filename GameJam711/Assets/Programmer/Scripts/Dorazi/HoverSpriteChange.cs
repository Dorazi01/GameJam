using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverSpriteChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image targetImage;         // �ٲ� �̹��� ���
    public Sprite originalSprite;     // ���� �̹���
    public Sprite hoverSprite;        // ���콺 �÷��� ���� �̹���

    // ���콺�� �÷��� �� ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null && hoverSprite != null)
        {
            targetImage.sprite = hoverSprite;
        }
    }

    // ���콺�� ���� �� ����
    public void OnPointerExit(PointerEventData eventData)
    {
        if (targetImage != null && originalSprite != null)
        {
            targetImage.sprite = originalSprite;
        }
    }
}
