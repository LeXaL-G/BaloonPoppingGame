using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TMP_Text highScoreTxt,scoreTxt;
    private int highScore;

    private void Start()
    {
        highScoreTxt.text = PlayerPrefs.GetInt("highScore").ToString();
        scoreTxt.text = PlayerPrefs.GetInt("score").ToString();
    }

    public void ReplaceGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
