using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void ChangeScenes(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        // ÇØ´ç ¾À Á¾·á.
        Application.Quit();
    }
}
