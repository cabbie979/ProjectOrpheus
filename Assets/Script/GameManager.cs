using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private GameObject _shopPanel;

    private Player player;
    public Player Player => player;

    private void Start()
    {
        _startScreen.SetActive(true);
        
    }

    public void StartGame()
    {
        _startScreen.SetActive(false);
        _levelPanel.SetActive(true);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("Level1Scene");
        _levelPanel.SetActive(false);
    } 

    public void OpenShopPanel()
    {
        _shopPanel.SetActive(true);
        _startScreen.SetActive(false);
    }

    public void CloseShopPanel()
    {
        _shopPanel.SetActive(false);
        _startScreen.SetActive(true);

    }

    public void CloseLevelPanel()
    {
        _levelPanel.SetActive(false);
        _startScreen.SetActive(true);
    }

    public void DeleteCoin()
    {
        SaveLoad.DeleteCoin();
    }

}
