using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private int _attempts;
    [SerializeField] private int _level;
    [SerializeField] private int _levelToLoad;
    [SerializeField] private int bossRoomLevel;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void SavePlayer() // Save player data
    {
        SaveSystem.SavePlayer(_attempts, _level);
    }

    public void LoadPlayer() // Load player data
    {
        PlayerData data = SaveSystem.LoadPlayer();

        _attempts = data.Attempts;
        _level = data.Level;
    }
    
    public void ActivateLoose() // Descrease attempts and restart scene
    {
        --_attempts;
        if (_attempts <= 0)
        {
            _levelToLoad = 0;
        }
        SavePlayer();
        FadeToLevel();
    }

    public void ActivateWin() // Increase level value and restart scene
    {
        ++_level;
        if (_levelToLoad >= bossRoomLevel)
        {
            _levelToLoad = 2;
        }
        SavePlayer();
        FadeToLevel();
    }

    public void StartNewGame() // Reset data and start new game
    {
        SavePlayer();
        FadeToLevel();
    }

    public void FadeToLevel() // Active animation 
    {
        _anim.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

    public void AddAttempt(int add)
    {
        _attempts += add;
    }

    public int GetAttempts()
    {
        return _attempts;
    }
}
