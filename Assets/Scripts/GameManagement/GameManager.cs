using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private Action[] _actions;
    [SerializeField] private float _speedToAdd;
    [SerializeField] private int _attemptsToAdd;

    private LevelChanger _lc;
    private PlayerMovement _pm;
    private PlayerCombat _pc;
    private CameraMove _cm;

    private void Awake()
    {
        _lc = FindObjectOfType<LevelChanger>().GetComponent<LevelChanger>();
        _pm = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        _pc = FindObjectOfType<PlayerCombat>().GetComponent<PlayerCombat>();
        _cm = FindObjectOfType<CameraMove>().GetComponent<CameraMove>();
    }

    private void Start()
    {
        _lc.LoadPlayer();
        _actions[0] = AddSpeed;
        _actions[1] = AddAttempts;
    }

    public void AddJump(int add)
    {
        _pm.AddExtraJumps(add);
    }

    public void AddDamage(int add)
    {
        _pc.IncreaseDamage(add);
    }
    
    public void CameraSlowDown(int slow)
    {
        _cm.SlowDown(slow);
    }
    
    public void Randomize()
    {
        int randomIndex = UnityEngine.Random.Range(0, _actions.Length - 1);
        _actions[randomIndex].Invoke();
    }

    private void AddSpeed()
    {
        _pm.AddSpeed(_speedToAdd);
    }

    private void AddAttempts()
    {
        _lc.AddAttempt(_attemptsToAdd);
    } 
}
