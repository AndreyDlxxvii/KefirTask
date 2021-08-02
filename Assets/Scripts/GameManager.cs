using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Text _valueScore;
    [SerializeField] private Button _restart;
    [SerializeField] private Text _gameOverText;

    public bool _flag;
    
    private int _numberOfSpawn;
    private SpawnEnemy _spawnEnemy;
    private int _waveOfAsteroid = 2;
    private int _score;
    private float _timer;
    public bool MySprite = true;
    

    
    
    void Start()
    {
        _spawnEnemy = GetComponent<SpawnEnemy>();
        Instantiate(_player, Vector3.zero, quaternion.identity);
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MySprite = !MySprite;
        }
        
        //Спавн астероидов
        if (!GameObject.FindWithTag("Enemy"))
        {
           _spawnEnemy.SpawnAsteroid(_waveOfAsteroid, MySprite);
           _waveOfAsteroid =+5;
        }

        _timer += Time.deltaTime;
        
        //Спавн НЛО
        if (_timer > 6f)
        {
            _spawnEnemy.SpawnUfo(MySprite);
            _timer = 0f;
        }
    }
   
   //Телепорт
    private void OnTriggerExit(Collider other)
    {
        var i = other.gameObject.transform.position;
        other.gameObject.transform.position = i * -1;
    }

    public void ScoreIncrement()
    {
        _score++;
        _valueScore.text = _score.ToString();
    }

    public void EndGame()
    {
        _restart.gameObject.SetActive(true);
        _restart.onClick.AddListener(RestartGameButton);
        _gameOverText.gameObject.SetActive(true);
        _gameOverText.gameObject.transform.GetChild(0).GetComponent<Text>().text = _score.ToString();
    }
    
    public void RestartGameButton()
    {
        SceneManager.LoadScene(0);
    }
}
