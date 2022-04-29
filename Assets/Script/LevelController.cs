using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private List<GameObject> _levels = null;
    [Header("References")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _finishPrefab;
    [SerializeField] private GameObject _altarPrefab;
    [Header("Panel")]
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _gameOverPanel;

    

    private int _levelNum = 0;
    private LevelController _currentLevel = null;

    private Player player;
    public Player Player => player;

    private Vector2 playerPosition = Vector2.zero;

    private void Start()
    {
        _startScreen.SetActive(true);
    }

    public void StartGame()
    {
        InstantiateLevel(_levelNum, out _currentLevel);
        GeneratePlayer();
        _startScreen.SetActive(false);
        _finishPanel.SetActive(false);
        
    }

    

    private void GeneratePlayer()
    {
        player = Instantiate(_player, transform).GetComponent<Player>();
        
        
    }

    private void InstantiateLevel(int index, out LevelController level)
    {
        if(index >= _levels.Count)
        {
            index = index % _levels.Count;
        }

        if(_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
        }

        level = Instantiate(_levels[index], transform).GetComponent<LevelController>();
    }

    public void Finish()
    {
        
        _finishPanel.SetActive(true);
    }
    
}
