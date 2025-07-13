using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
{
    public static SenceManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public string mainMenu = "StartScene";   // 메인 메뉴 씬 이름
    public string Level1 = "Level1";
    public string Level2 = "Level2";
    public string Level3 = "Level3";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //  EndGame 버튼용: 게임 종료
    public void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    //  GameOver 화면에서 메인 메뉴로 이동
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
