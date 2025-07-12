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

    // UIMananger Ŭ���� ���ο� �߰�
    public TextMeshProUGUI dialogText; // Inspector���� �Ҵ�
    string dialogText2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameTImeText; // ���� �ð� ǥ�ÿ� �ؽ�Ʈ   

    public GameObject dialogBox;
    public GameObject answerBasket;

    public Scrollbar OrderTimeScrollbar;

    public GameObject NpcPrefab;

    public int NpcsprNum; // NPC ��������Ʈ ��ȣ


    public int realAnswer; // ���� ����
    public int realMood; // ���� ���
    
    string winText;
    string loseText;
    string wrongFoodText; // �߸��� ���� �ؽ�Ʈ
    string wrongMoodText; // �߸��� ��� �ؽ�Ʈ



    private Dialog dialog;

    private string lastOrderText; //�ֹ� ����
    public GameObject orderReviewBox;  // �ֹ� �ٽú���� UI ������Ʈ

    public GameObject recipeBox; // ���� ���� ������ �ڽ� ������Ʈ
    public TextMeshProUGUI recipeText; // RecipeBox �ȿ� �ִ� �ؽ�Ʈ

    public bool RawDoughCreate = false; // ���� ���¸� ��Ÿ���� ����



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

        dialog = new Dialog(); // Dialog �ν��Ͻ� ����
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

       




    private string lastOrderText; //�ֹ� ����
    public GameObject orderReviewBox;  // �ֹ� �ٽú���� UI ������Ʈ

    public GameObject recipeBox; // ���� ���� ������ �ڽ� ������Ʈ
    public TextMeshProUGUI recipeText; // RecipeBox �ȿ� �ִ� �ؽ�Ʈ

    public bool RawDoughCreate = false; // ���� ���¸� ��Ÿ���� ����


            string dialogText2;

    private Dialog dialog;
    
    string winText;
    string loseText;
    string wrongFoodText; // �߸��� ���� �ؽ�Ʈ
    string wrongMoodText; // �߸��� ��� �ؽ�Ʈ


         
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
            GameManager.instance.IncreaseScore(); // ���� ����

            Debug.Log("�����Դϴ�! ������ �����߽��ϴ�.");
            dialogText.text = winText; // �¸� �޽��� ���


        }
        else if (GameManager.instance.currentAnswer == realAnswer && GameManager.instance.curEffect != realMood)
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.correctSprites[UIMananger.instance.NpcsprNum];
            GameManager.instance.IncreaseScore(); // ���� ����
            dialogText.text = wrongMoodText; // �¸� �޽��� ���
        }
        else if (GameManager.instance.currentAnswer != realAnswer && GameManager.instance.curEffect == realMood)
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.correctSprites[UIMananger.instance.NpcsprNum];
            GameManager.instance.IncreaseScore(); // ���� ����
            dialogText.text = wrongFoodText; // �¸� �޽��� ���
        }
        else
        {
            NPCBehaviour.instance.spriteRenderer.sprite = NPCBehaviour.instance.wrongSprites[UIMananger.instance.NpcsprNum];
            Debug.Log("�ؽ�.");
            dialogText.text = loseText; // �¸� �޽��� ���
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

        realAnswer = entry.Food; // ���� ������ �������� ����
        realMood = entry.Mood; 

        if (entry != null && dialogText != null)
            dialogText.text = entry.Text1; // ��縸 ���
            dialogText2 = entry.Text2; // ���2�� ���� (�߰��� ���� �� ����)


        lastOrderText = entry.Text1; // �ֹ� ���常 ����


        NpcsprNum = entry.CharNum; // NPC ��������Ʈ ��ȣ ����
        winText = entry.WinText; // �¸� �޽��� ����
        loseText = entry.LoseText; // �й� �޽��� ����
        wrongFoodText = entry.WrongFood; // �߸��� ���� �ؽ�Ʈ ����
        wrongMoodText = entry.WrongMood; // �߸��� ��� �ؽ�Ʈ ����

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
                orderReviewBox.SetActive(false); // ���� ������ ����
            }
            else
            {
                orderReviewBox.SetActive(true); // ���� ������ �ѱ�

                // �ֹ� �ؽ�Ʈ ����
                TextMeshProUGUI orderText = orderReviewBox.GetComponentInChildren<TextMeshProUGUI>();
                if (orderText != null)
                {
                    orderText.text = lastOrderText;
                }
                else
                {
                    Debug.LogWarning("orderReviewBox ���� TextMeshProUGUI ������Ʈ�� �����ϴ�.");
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
                    "�Ź�ġ�� + ����� = ���ڻ�\n" +
                    "�Ź�ġ�� + �������� = ����\n" +
                    "�������� + ����� = ��������ũ\n" +
                    "�Ź�ġ�� = ġ��Ļ�\n" +
                    "����� = ���� ����\n" +
                    "�������� = �������� ����";
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

            //OrderTimeScrollbar.size = NpcPrefab.GetComponent<NPCBehaviour>().curTime / 40f; // NPC�� ���� �ð��� ���� ��ũ�ѹ� �� ������Ʈ
            timerImage.fillAmount = NPCBehaviour.instance.curTime / NPCBehaviour.instance.lifeTime; // NPC�� ���� �ð��� ���� Ÿ�̸� �̹��� ������Ʈ
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
        // ���� �����鼭 ���� ���� (�̹� ���� �� ������)
        if (!RawDoughCreate)
        {
            RecipeManager.instance.RawDough.SetActive(true);
            RawDoughCreate = true;
            Debug.Log("������ ������ �����Ǿ����ϴ�.");
        }

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



    public void onclickMood1()
    {
        GameManager.instance.curEffect = 1; // 1 = ����
    }
    public void onclickMood2()
    {
        GameManager.instance.curEffect = 2; // 2 = ����
    }
    public void onclickMood3()
    {
        GameManager.instance.curEffect = 3; // 3 = �����
    }
    public void onclickMood4()
    {
        GameManager.instance.curEffect = 4; // 4 = ���
    }
    public void onclickMood5()
    {
        GameManager.instance.curEffect = 5; // 5 = �Ҿ�
    }
    public void onclickMood6()
    {
        GameManager.instance.curEffect = 6; // 6 = �г�
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