using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMananger : MonoBehaviour
{
    public Scrollbar timerScrollbar;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        if (GameManager.instance != null && timerScrollbar != null)
        {
            timerScrollbar.size = GameManager.instance.CurTIme / GameManager.instance.MaxTime;
        }

        scoreText.text = "Score: " + GameManager.instance.score.ToString();


    }
}