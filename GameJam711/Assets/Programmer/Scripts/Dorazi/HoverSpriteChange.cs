using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverSpriteChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image targetImage;         // 바꿀 이미지 대상
    public Sprite originalSprite;     // 원래 이미지
    public Sprite hoverSprite;        // 마우스 올렸을 때의 이미지

    public AudioSource audioSource;   // 사운드 재생용 AudioSource
    public AudioClip hoverSound;      // 마우스 오버 사운드 클립

    // 마우스를 올렸을 때 실행
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (targetImage != null && hoverSprite != null)
        {
            targetImage.sprite = hoverSprite;
        }

        if (audioSource != null && hoverSound != null)
        {
            audioSource.PlayOneShot(hoverSound);  // 짧은 사운드에 적합
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
