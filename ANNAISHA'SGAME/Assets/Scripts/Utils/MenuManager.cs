using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  public void NewGame()
    {
        SceneManager.LoadScene("ANNAISHA_BACKUP");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
