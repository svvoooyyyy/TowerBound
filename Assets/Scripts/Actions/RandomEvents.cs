using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] _images;
    [SerializeField] private PlayerMovement _playerMovement;

    public void Block()
    {
        for (int i = 0; i < _images.Length; ++i)
        {
            _images[i].SetActive(true);
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
