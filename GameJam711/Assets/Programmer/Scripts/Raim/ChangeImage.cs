using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image targetImage;         // 바꿀 이미지 컴포넌트
    public Sprite originalSprite;     // 원래 이미지
    public Sprite changedSprite;      // 변경할 이미지

    private bool isOriginal = true;   // 현재 이미지 상태 체크

    public void OnButtonClick()
    {
        if (isOriginal)
        {
            targetImage.sprite = changedSprite;
            isOriginal = false;

            Invoke("ResetImage", 2f); 
        }

    }

    public void ResetImage()
    {
        targetImage.sprite = originalSprite;
        isOriginal = true;
    }
}

