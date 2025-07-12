using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image targetImage;         // �ٲ� �̹��� ������Ʈ
    public Sprite originalSprite;     // ���� �̹���
    public Sprite changedSprite;      // ������ �̹���

    private bool isOriginal = true;   // ���� �̹��� ���� üũ

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

