using UnityEngine;
using System.Collections;

public class BakeButtonMover : MonoBehaviour
{
    public RectTransform bakeButton; // 이동시킬 버튼의 RectTransform
    public float moveAmount = 100f;   // 얼마나 위로 올라갈지
    public float moveDuration = 0.5f; // 올라가고 내려오는 데 걸리는 시간

    public void StartBounceAnimation()
    {
        StartCoroutine(BounceRoutine());
    }

    private IEnumerator BounceRoutine()
    {
        Vector2 originalPos = bakeButton.anchoredPosition;
        Vector2 targetPos = originalPos + new Vector2(0, moveAmount);

        // 위로 이동
        float timer = 0f;
        while (timer < moveDuration)
        {
            
            timer += Time.deltaTime;
            bakeButton.anchoredPosition = Vector2.Lerp(originalPos, targetPos, timer / moveDuration);
            yield return null;

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }


        }
        


        yield return new WaitForSeconds(1f); // 1초 기다림

        


        // 원래 위치로 되돌아감
        timer = 0f;
        while (timer < moveDuration)
        {
            timer += Time.deltaTime;
            bakeButton.anchoredPosition = Vector2.Lerp(targetPos, originalPos, timer / moveDuration);
            yield return null;
        }
    }
}
