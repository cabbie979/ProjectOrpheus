using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _failPanel;
    [SerializeField] private GameObject _exitButton;

    private void Start()
    {
        _winPanel.SetActive(false);
        _failPanel.SetActive(false);
        _exitButton.SetActive(true);
        BowShoot.onWin += Win;
        Enemy.onFail += Fail;
    }

    public void Win()
    {
         _exitButton.SetActive(false);
         _winPanel.SetActive(true);
        BowShoot.onWin -= Win;
    }

    public void Fail()
    {
        _exitButton.SetActive(true);
        _failPanel.SetActive(true);
        Enemy.onFail -= Fail;
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Repeat()
    {
        SceneManager.LoadScene("Level1Scene");
    }
}
