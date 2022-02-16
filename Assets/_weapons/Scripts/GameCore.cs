using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class playerStats
{
    public int animationSlected = 0;
}

public class GameCore : Singleton<GameCore>
{
    public playerStats stats = new playerStats();

    #region UnityBehaviour
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    public void SelectAnimation(int value)
    {
        stats.animationSlected = value;

        SceneManager.LoadSceneAsync("weapons");
    }
}
