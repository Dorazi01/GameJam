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

    bool isUIMoving = false; // UI가 움직이는 중인지 여부를 나타내는 변수

    // DomaBackGround를 화면 안으로 슬라이드하는 메서드
    public void ShowDomaBackGround()
    {
        if (isUIMoving) return; // 이미 UI가 움직이고 있다면 중복 실행 방지
        isUIMoving = true;
        StartCoroutine(SlideInDomaBackGround());
        isUIMoving = false;

    }

    public void CloseDomaBackGround()
    {
        if (isUIMoving) return; // 이미 UI가 움직이고 있다면 중복 실행 방지
        isUIMoving = true;
        StartCoroutine(SlideOutDomaBackGround());
        isUIMoving = false;
    }


    IEnumerator SlideInDomaBackGround()
    {
        // 화면 밖 시작 위치 (예: 왼쪽으로 800px)
        Vector2 startPos = new Vector2(1944, domaBackGround.anchoredPosition.y);
        // 화면 안 도착 위치 (예: 0, 현재 y)
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
        // 화면 밖 시작 위치 (예: 왼쪽으로 800px)
        Vector2 startPos = new Vector2(0, domaBackGround.anchoredPosition.y);
        // 화면 안 도착 위치 (예: 0, 현재 y)
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