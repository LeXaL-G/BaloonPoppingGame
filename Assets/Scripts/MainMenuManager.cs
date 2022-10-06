using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public TMP_Text highScore;
    public GameObject settingMenu;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void settingOn()
    {
        settingMenu.SetActive(true);
    }

    public void dataDelete()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void settingOff()
    {
        settingMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
