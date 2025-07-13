using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMananger : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject optionUI;

    public void clickPauseBtn()
    {
        if (GameManager.instance.isGameOver) return;
        
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        
        
    }

    public void clickResumeBtn()
    {
        if (GameManager.instance.isGameOver) return;
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void clickOptionBtn()
    {
        pauseUI.SetActive(false);
        optionUI.SetActive(true);
    }
}