using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private int _attempts;
    [SerializeField] private int _level;
    [SerializeField] private int _levelToLoad;

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
        SavePlayer();
        FadeToLevel();
    }

    public void ActivateWin() // Increase level value and restart scene
    {
        ++_level;
        SavePlayer();
        FadeToLevel();
    }

    public void StartNewGame()
    {
        SavePlayer();
        FadeToLevel();
    }

    public void FadeToLevel()
    {
        _anim.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(_levelToLoad);
    }
}
