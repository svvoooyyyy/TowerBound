using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadGame : MonoBehaviour
{
    private LevelChanger _levelChanger;

    private void Awake()
    {
        _levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void Start()
    {
        _levelChanger.LoadPlayer();
    }
}
