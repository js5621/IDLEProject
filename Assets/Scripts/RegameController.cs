using UnityEngine;
using UnityEngine.SceneManagement;

public class RegameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GameRetry()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToGameMenu()
    {
        SceneManager.LoadScene(0);
    }
}
