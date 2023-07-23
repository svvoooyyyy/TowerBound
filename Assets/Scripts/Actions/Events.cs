using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    [SerializeField] private PlayerMovement _playerMovement;

    public void Block()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].enabled = true;
        }
    }

    public void ChangeGravity()
    {
        _playerMovement.ChangeGravity();
    }

    public void ChangeScale()
    {
        _playerMovement.ChangePlayerScale();
    }
}
