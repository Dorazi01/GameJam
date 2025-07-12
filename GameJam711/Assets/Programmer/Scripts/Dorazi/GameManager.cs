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
    //0 = 없음, 1 = 공포, 2 = 좌절, 3 = 무기력, 4 = 열등, 5 = 불안, 6 = 분노

    public float MaxTime;
    public float CurTIme;

    public bool isGameOver= false;

    private void Awake()
    {
        
        
        instance = this;
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
    }

    public void IncreaseScore()
    {
        score += 100;

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
