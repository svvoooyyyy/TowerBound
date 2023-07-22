using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _attempts;
    [SerializeField] private int _level;

    private void Start()
    {
        LoadPlayer();
    }

    private void SavePlayer()
    {
        SaveSystem.SavePlayer(_attempts, _level);
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        _attempts = data.Attempts;
        _level = data.Level;
    }

    public void ActivateLoose()
    {
        --_attempts; 
        ToggleLevel();
    }

    public void ActivateWin()
    {
        ++_level;
        ToggleLevel();
    }

    public void ToggleLevel()
    {
        SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
