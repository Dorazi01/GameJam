using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMananger : MonoBehaviour
{
    public Image timerImage;

    
    public RectTransform domaBackGround;
    public static UIMananger instance;
    public GameObject TimeOverWindow;

    // UIMananger 클래스 내부에 추가
    public TextMeshProUGUI dialogText; // Inspector에서 할당
    string dialogText2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameTImeText; // 게임 시간 표시용 텍스트   

    public GameObject dialogBox;
    public GameObject answerBasket;

    public Scrollbar OrderTimeScrollbar;

    public GameObject NpcPrefab;

    public int NpcsprNum; // NPC 스프라이트 번호


    public int realAnswer; // 실제 정답
    public int realMood; // 실제 기분
    
    string winText;
    string loseText;
    string wrongFoodText; // 잘못된 음식 텍스트
    string wrongMoodText; // 잘못된 기분 텍스트



    private Dialog dialog;

    private string lastOrderText; //주문 저장
    public GameObject orderReviewBox;  // 주문 다시보기용 UI 오브젝트

    public GameObject recipeBox; // 새로 만든 레시피 박스 오브젝트
    public TextMeshProUGUI recipeText; // RecipeBox 안에 있는 텍스트

    public bool RawDoughCreate = false; // 반죽 상태를 나타내는 변수



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dialog = new Dialog(); // Dialog 인스턴스 생성
    }
 /*
    void Start()
    {
        domaBackGround = GameObject.Find("DomaBackGround").GetComponent<RectTransform>();
        TimeOverWindow = GameObject.Find("TimeOverWindow").GetComponent<GameObject>();
        dialogText = GameObject.Find("dialogText").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        gameTImeText = GameObject.Find("gameTImeText").GetComponent<TextMeshProUGUI>();
        dialogBox = GameObject.Find("dialogBox").GetComponent<GameObject>();
        answerBasket = GameObject.Find("answerBasket").GetComponent<GameObject>();
        OrderTimeScrollbar = GameObject.Find("OrderTimeScrollbar").GetComponent<Scrollbar>();
        NpcPrefab = GameObject.Find("NpcPrefab").GetComponent<GameObject>();
        NpcsprNum = GameObject.Find("NpcsprNum").GetComponent<int>();
        realAnswer = GameObject.Find("realAnswer").GetComponent<int>();
        realMood = GameObject.Find("realMood").GetComponent<int>();

       




    private string lastOrderText; //주문 저장
    public GameObject orderReviewBox;  // 주문 다시보기용 UI 오브젝트

    public GameObject recipeBox; // 새로 만든 레시피 박스 오브젝트
    public TextMeshProUGUI recipeText; // RecipeBox 안에 있는 텍스트

    public bool RawDoughCreate = false; // 반죽 상태를 나타내는 변수


            string dialogText2;

    private Dialog dialog;
    
    string winText;
    string loseText;
    string wrongFoodText; // 잘못된 음식 텍스트
    string wrongMoodText; // 잘못된 기분 텍스트


         
    }
*/

    public void ActiveDialogText()
    {
            dialogBox.gameObject.SetActive(true);
    }
    public void UnActiveDialogText()
    {
        dialogBox.gameObject.SetActive(false);
    }

    public void ActiveAnswerBasket()
    {
        answerBasket.gameObject.SetActive(true);
    }
    public void UnActiveAnswerBasket()
    {
        answerBasket.gameObject.SetActive(false);
    }


    public void PushAnswer()
    {
        Debug.Log($"winText: {winText}, loseText: {loseText}");
        if (GameManager.instance.currentAnswer == realAnswer&& GameManager.instance.curEffect == realMood)
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.correctSprites[UIMananger.instance.NpcsprNum];
            GameManager.instance.IncreaseScore(); // 점수 증가

            Debug.Log("정답입니다! 점수가 증가했습니다.");
            dialogText.text = winText; // 승리 메시지 출력


        }
        else if (GameManager.instance.currentAnswer == realAnswer && GameManager.instance.curEffect != realMood)
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.correctSprites[UIMananger.instance.NpcsprNum];
            GameManager.instance.IncreaseScore(); // 점수 증가
            dialogText.text = wrongMoodText; // 승리 메시지 출력
        }
        else if (GameManager.instance.currentAnswer != realAnswer && GameManager.instance.curEffect == realMood)
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.correctSprites[UIMananger.instance.NpcsprNum];
            GameManager.instance.IncreaseScore(); // 점수 증가
            dialogText.text = wrongFoodText; // 승리 메시지 출력
        }
        else
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.wrongSprites[UIMananger.instance.NpcsprNum];
            Debug.Log("붕슨.");
            dialogText.text = loseText; // 승리 메시지 출력
        }
        Invoke(nameof(CleanUp), 3f);
        
    }

    public void CleanUp()
    {
        RecipeManager.instance.Reset();
        NPCBehaviour.instance.DestroyNPC();
    }

  

    public void ShowRandomDialog(int level)
    {
        DialogEntry entry = dialog.GetRandomDialog(level);

        realAnswer = entry.Food; // 실제 정답을 음식으로 설정
        realMood = entry.Mood; 

        if (entry != null && dialogText != null)
            dialogText.text = entry.Text1; // 대사만 출력
            dialogText2 = entry.Text2; // 대사2도 저장 (추가로 사용될 수 있음)


        lastOrderText = entry.Text1; // 주문 문장만 저장


        NpcsprNum = entry.CharNum; // NPC 스프라이트 번호 저장
        winText = entry.WinText; // 승리 메시지 저장
        loseText = entry.LoseText; // 패배 메시지 저장
        wrongFoodText = entry.WrongFood; // 잘못된 음식 텍스트 저장
        wrongMoodText = entry.WrongMood; // 잘못된 기분 텍스트 저장

    }


    public void QueButtonIn()
    {
        dialogText.text = dialogText2;
    }

    public void QueButtonOut()
    {
        dialogText.text = lastOrderText ;
    }


    public void ShowLastOrder()
    {
        if (orderReviewBox != null)
        {
            if (orderReviewBox.activeSelf)
            {
                orderReviewBox.SetActive(false); // 켜져 있으면 끄기
            }
            else
            {
                orderReviewBox.SetActive(true); // 꺼져 있으면 켜기

                // 주문 텍스트 갱신
                TextMeshProUGUI orderText = orderReviewBox.GetComponentInChildren<TextMeshProUGUI>();
                if (orderText != null)
                {
                    orderText.text = lastOrderText;
                }
                else
                {
                    Debug.LogWarning("orderReviewBox 내에 TextMeshProUGUI 컴포넌트가 없습니다.");
                }
            }
        }
    }


    public void ShowRecipe()
    {
        if (recipeBox != null)
        {
            if (recipeBox.activeSelf)
            {
                recipeBox.SetActive(false);
            }
            else
            {
                recipeBox.SetActive(true);
                recipeText.text =
                    "거미치즈 + 산딸기 = 피자빵\n" +
                    "거미치즈 + 개구리알 = 도넛\n" +
                    "개구리알 + 산딸기 = 과일케이크\n" +
                    "거미치즈 = 치즈식빵\n" +
                    "산딸기 = 딸기 도넛\n" +
                    "개구리알 = 개구리알 머핀";
            }
        }
    }

    private void Update()
    {


        if (GameManager.instance != null && scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.instance.score.ToString();
        }

        if (GameManager.instance != null && gameTImeText != null)
        {
            float remainTime = GameManager.instance.MaxTime - GameManager.instance.CurTIme;
            int minutes = Mathf.FloorToInt(remainTime / 60f);
            int seconds = Mathf.FloorToInt(remainTime % 60f);
            gameTImeText.GetComponent<TMPro.TextMeshProUGUI>().text =
                $"{minutes:00}:{seconds:00}";
        }

        if (GameManager.instance != null && NpcPrefab != null)
        {

            //OrderTimeScrollbar.size = NpcPrefab.GetComponent<NPCBehaviour>().curTime / 40f; // NPC의 생존 시간에 따라 스크롤바 값 업데이트
            timerImage.fillAmount = NPCBehaviour.instance.curTime / NPCBehaviour.instance.lifeTime; // NPC의 생존 시간에 따라 타이머 이미지 업데이트
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
        // 도마 열리면서 반죽 생성 (이미 생성 안 됐으면)
        if (!RawDoughCreate)
        {
            RecipeManager.instance.RawDough.SetActive(true);
            RawDoughCreate = true;
            Debug.Log("도마에 반죽이 생성되었습니다.");
        }

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



    public void onclickMood1()
    {
        GameManager.instance.curEffect = 1; // 1 = 공포
    }
    public void onclickMood2()
    {
        GameManager.instance.curEffect = 2; // 2 = 좌절
    }
    public void onclickMood3()
    {
        GameManager.instance.curEffect = 3; // 3 = 무기력
    }
    public void onclickMood4()
    {
        GameManager.instance.curEffect = 4; // 4 = 열등감
    }
    public void onclickMood5()
    {
        GameManager.instance.curEffect = 5; // 5 = 불안
    }
    public void onclickMood6()
    {
        GameManager.instance.curEffect = 6; // 6 = 분노
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