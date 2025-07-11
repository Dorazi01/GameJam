using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
{
    public static SenceManager instance;

    public string stage1 = "Stage1";
    public string stage2 = "Stage2";
    public string stage3 = "Stage3";
    public string stage4 = "Stage4";
    public string stage5 = "Stage5";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
 
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
