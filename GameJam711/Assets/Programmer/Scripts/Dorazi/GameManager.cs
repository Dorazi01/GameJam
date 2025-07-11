using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int npcLevel;
    public int score;

    public float MaxTime;
    public float CurTIme;

    public bool isGameOver= false;

    private void Awake()
    {
        
        if (instance != null)
        {
            instance = this;
            
        }

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
        MaxTime = 120f;
        CurTIme = 0f;
    }

    void IncreaseScore()
    {
        score += 100 * npcLevel;

    }

    void TimeOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
    }
}
