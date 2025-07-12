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
        MaxTime = 3f;
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
