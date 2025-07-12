using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMananger : MonoBehaviour
{
    public RectTransform domaBackGround;
    public static UIMananger instance;

    // UIMananger Ŭ���� ���ο� �߰�
    public TextMeshProUGUI dialogText; // Inspector���� �Ҵ�
    public TextMeshProUGUI scoreText;
    public GameObject dialogBox;
    public GameObject answerBasket;

    public int realAnswer; // ���� ����
    string winText;
    string loseText;


    private Dialog dialog;

    private string lastOrderText; //�ֹ� ����
    public GameObject orderReviewBox;  // �ֹ� �ٽú���� UI ������Ʈ

    public GameObject recipeBox; // ���� ���� ������ �ڽ� ������Ʈ
    public TextMeshProUGUI recipeText; // RecipeBox �ȿ� �ִ� �ؽ�Ʈ

    public bool RawDoughCreate = false; // ���� ���¸� ��Ÿ���� ����

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
        if (GameManager.instance.currentAnswer == realAnswer)
        {
            GameManager.instance.IncreaseScore(); // ���� ����

            Debug.Log("�����Դϴ�! ������ �����߽��ϴ�.");
            dialogText.text = winText; // �¸� �޽��� ���



        }
        else
        {
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

        dialog = new Dialog(); // Dialog �ν��Ͻ� ����
    }
    public void ShowRandomDialog(int level)
    {
        DialogEntry entry = dialog.GetRandomDialog(level);

        realAnswer = entry.Value; 

        if (entry != null && dialogText != null)
            dialogText.text = entry.Text; // ��縸 ���

        lastOrderText = entry.Text; // �ֹ� ���常 ����
        winText = entry.WinText; // �¸� �޽��� ����
        loseText = entry.LoseText; // �й� �޽��� ����

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