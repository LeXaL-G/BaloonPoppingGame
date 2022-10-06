using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TextMeshProUGUI scoreTxt,healthTxt;
    public int score = 0, health = 5, levelScore = 0, attentionPanelControl = 0;
    public float speed=5f,pauseControl=0;
    public GameObject pausePanel,attentionPanel;

    void Start()
    {
        PlayerPrefs.DeleteKey("score");
        scoreTxt = GameObject.Find("Canvas/Score.txt").GetComponent<TextMeshProUGUI>();
        healthTxt = GameObject.Find("Canvas/Image/Health.txt").GetComponent<TextMeshProUGUI>();
        scoreTxt.text = $"SCORE: {score}";
    }

    private void Update()
    {
        PlayerPrefs.SetInt("score",score);
        if (PlayerPrefs.GetInt("highScore")<score)
        {
            PlayerPrefs.SetInt("highScore",score);
        }
        healthTxt.text = health.ToString();
    }
    
    public void totalScore()
    {
        score += 10;
        levelScore += 10;
        scoreTxt.text = $"SCORE: {score}";
    }

    public void Health()
    {
        health--;
        healthTxt.text = health.ToString();
    }
    
    public void BalonSpeed()
    {
        if (levelScore == 100)
        {
            speed += 5f;
            levelScore = 0;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseControl = 1f;
        pausePanel.SetActive(true);
    }

    public void PlayGame()
    {
        pausePanel.SetActive(false);
        pauseControl = 0;
        Time.timeScale = 1;
    }

    public void MainMenuBtn()
    {
        if(attentionPanelControl==0)
        {
            attentionPanel.SetActive(true);
            attentionPanelControl = 1;
        }        
    }

    public void NoMainMenu()
    {
        attentionPanelControl = 0;
        attentionPanel.SetActive(false);
    }

    public void GotoMainMenu()
    {
        attentionPanelControl = 0;
        SceneManager.LoadScene(0);
    }
    
    
    
}

