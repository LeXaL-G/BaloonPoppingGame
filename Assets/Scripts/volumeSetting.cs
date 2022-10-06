using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class volumeSetting : MonoBehaviour
{
    public TMP_Text soundVolume,balloonPoppingVolume;
    public Slider gameMusicSlider,balloonPoppingSlider;
    public Toggle toggle;
    public GameObject explosion,healthExplotion,enemyExplosion;
    private GameSound _gameSound;

    private void Start()
    {
        _gameSound = GameObject.Find("GameSound").GetComponent<GameSound>();
        toggle.GetComponent<Toggle>();
        if (PlayerPrefs.GetInt("volume") == 1)
            toggle.isOn = true;
        else
            toggle.isOn = false;
        LoadAudio();
        LoadAudioBalloon();
    }

    private void Update()
    {
        VolumeControl(toggle.isOn);
        SetAudio(PlayerPrefs.GetFloat("audioVolume"));
        SetBalloonAudio(PlayerPrefs.GetFloat("audioBalloonVolume"));
        soundVolume.text = ((int)(gameMusicSlider.value*100)).ToString();
        balloonPoppingVolume.text=((int)(balloonPoppingSlider.value*100)).ToString();
    }

    #region Oyun Genel Ses Ayarları

    public void VolumeControl(bool value)
    {
        if (value)
            VolumeOn();
        else
            VolumeOff();
    }

    public void VolumeOn()
    {
        PlayerPrefs.SetInt("volume", 1);
    }

    public void VolumeOff()
    {
        PlayerPrefs.SetInt("volume", 0);
    }

    #endregion

    #region Oyun Müzik Ses Ayarları

    // ReSharper disable Unity.PerformanceAnalysis
    public void SetAudio(float value)
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            _gameSound.GetComponent<AudioSource>().volume = value;
            soundVolume.text = ((int)(value * 100)).ToString();
            SaveAudio();
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", _gameSound.GetComponent<AudioSource>().volume);
    }

    void LoadAudio()
    {
        _gameSound.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("audioVolume");
        gameMusicSlider.value = PlayerPrefs.GetFloat("audioVolume");
    }

    #endregion

    #region Balon Patlama Ses Ayarları

    public void SetBalloonAudio(float value)
    {
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            explosion.GetComponent<AudioSource>().volume = value;
            healthExplotion.GetComponent<AudioSource>().volume = value;
            enemyExplosion.GetComponent<AudioSource>().volume = value;
            balloonPoppingVolume.text = ((int)(value * 100)).ToString();
            SaveAudioBalloon();
        }
        else
        {
            AudioListener.volume = 0;
        }
    }

    void SaveAudioBalloon()
    {
        PlayerPrefs.SetFloat("audioBalloonVolume", explosion.GetComponent<AudioSource>().volume);
        PlayerPrefs.SetFloat("audioBalloonVolume", healthExplotion.GetComponent<AudioSource>().volume);
        PlayerPrefs.SetFloat("audioBalloonVolume", enemyExplosion.GetComponent<AudioSource>().volume);
    }

    void LoadAudioBalloon()
    {
        explosion.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("audioBalloonVolume");
        healthExplotion.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("audioBalloonVolume");
        enemyExplosion.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("audioBalloonVolume");
        balloonPoppingSlider.value = PlayerPrefs.GetFloat("audioBalloonVolume");
    }

    #endregion
}