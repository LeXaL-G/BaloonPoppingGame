using System;
using TMPro;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    static GameSound instance = null;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    

    
    
}