using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int npcLevel = 1;
    public int score;
    public int currentAnswer = 0;
    public bool isCorrectAnswer = false;
    public int currentMood = 0;

    public int curEffect = 0;
    //0 = ����, 1 = ����, 2 = ����, 3 = �����, 4 = ����, 5 = �Ҿ�, 6 = �г�

    public float MaxTime;
    public float CurTIme;

    public bool isGameOver= false;

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

        SetNpcLevelByScene();

        Init();
    }



    private void Update()
    {
        CurTIme += Time.deltaTime;




        if (CurTIme >= MaxTime)
        {
            TimeOver();
        }
    }



    void Init()
    {
        score = 0;
        isGameOver = false;
        MaxTime = 100f;
        CurTIme = 0f;
        Time.timeScale = 1f;
    }

    public void IncreaseScore()
    {
       

        if (NPCBehaviour.instance.curTime < 10f)
        {
            score += 150;
        }
        else if (NPCBehaviour.instance.curTime < 20f)
        {
            score += 130;
        }
        else
        {
            score += 100;
        }


    }

    void TimeOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        UIMananger.instance.TimeOverWindow.SetActive(true);
    }

    void SetNpcLevelByScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Level1":
                npcLevel = 1;
                break;
            case "Level2":
                npcLevel = 2;
                break;
            case "Level3":
                npcLevel = 3;
                break;
            default:
                npcLevel = 1;
                break;
        }
    }

}
