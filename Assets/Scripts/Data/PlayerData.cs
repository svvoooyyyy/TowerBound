using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int Attempts;
    public int Level;

    public PlayerData(int attempts, int level)
    {
        Attempts = attempts;
        Level = level;
    }
}
