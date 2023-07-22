using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelChanger _lc;

    private void Awake()
    {
        _lc = FindObjectOfType<LevelChanger>().GetComponent<LevelChanger>();
    }

    private void Start()
    {
        _lc.LoadPlayer();
    }
}
