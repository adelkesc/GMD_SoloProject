using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool isDead = false;
    public GameObject gameOverMenuUI;

    // Update is called once per frame
    void Update()
    {
       if(isDead)
        {
            gameOverMenuUI.SetActive(true);
            if (Input.GetButtonDown("Restart"))
            {
                isDead = false;
                StartCoroutine(RestartGameAsync());
            }
        }
        else
        {
            gameOverMenuUI.SetActive(false);
        }
    }
    public void ReturnToMainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        isDead = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    IEnumerator RestartGameAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
