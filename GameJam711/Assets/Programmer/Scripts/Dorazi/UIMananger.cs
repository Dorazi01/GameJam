using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMananger : MonoBehaviour
{
    public RectTransform domaBackGround;
    public static UIMananger instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        

         if (GameManager.instance != null && scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.instance.score.ToString();
        }
        


    }

    bool isUIMoving = false; // UI�� �����̴� ������ ���θ� ��Ÿ���� ����

    // DomaBackGround�� ȭ�� ������ �����̵��ϴ� �޼���
    public void ShowDomaBackGround()
    {
        if (isUIMoving) return; // �̹� UI�� �����̰� �ִٸ� �ߺ� ���� ����
        isUIMoving = true;
        StartCoroutine(SlideInDomaBackGround());
        isUIMoving = false;

    }

    public void CloseDomaBackGround()
    {
        if (isUIMoving) return; // �̹� UI�� �����̰� �ִٸ� �ߺ� ���� ����
        isUIMoving = true;
        StartCoroutine(SlideOutDomaBackGround());
        isUIMoving = false;
    }


    IEnumerator SlideInDomaBackGround()
    {
        // ȭ�� �� ���� ��ġ (��: �������� 800px)
        Vector2 startPos = new Vector2(1944, domaBackGround.anchoredPosition.y);
        // ȭ�� �� ���� ��ġ (��: 0, ���� y)
        Vector2 endPos = new Vector2(0, domaBackGround.anchoredPosition.y);

        domaBackGround.anchoredPosition = startPos;

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            domaBackGround.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        domaBackGround.anchoredPosition = endPos;
    }



    IEnumerator SlideOutDomaBackGround()
    {
        // ȭ�� �� ���� ��ġ (��: �������� 800px)
        Vector2 startPos = new Vector2(0, domaBackGround.anchoredPosition.y);
        // ȭ�� �� ���� ��ġ (��: 0, ���� y)
        Vector2 endPos = new Vector2(1944, domaBackGround.anchoredPosition.y);

        domaBackGround.anchoredPosition = startPos;

        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            domaBackGround.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        domaBackGround.anchoredPosition = endPos;
    }






    public void StartButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OptionButtonClick()
    {

    }

    public void FyButtonClick()
    {
        Application.Quit();
    }

    public void Stage1ButtonClick()
    {
        SceneManager.LoadScene("Level1");
        GameManager.instance.npcLevel = 1; // Set the NPC level for Level 1
    }

    public void Stage2ButtonClick()
    {
        SceneManager.LoadScene("Level2");
        GameManager.instance.npcLevel = 2; // Set the NPC level for Level 2
    }

    public void Stage3ButtonClick()
    {
        SceneManager.LoadScene("Level3");
        GameManager.instance.npcLevel = 3; // Set the NPC level for Level 3
    }
}