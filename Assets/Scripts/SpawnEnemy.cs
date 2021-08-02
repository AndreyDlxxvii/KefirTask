using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject [] Asteroids;
    public GameObject MyUfo;
    
    private int _numOfAsteroid;
    private SpawnPoints _mySpawnPoints;

    private void Awake()
    {
        _mySpawnPoints = GetComponent<SpawnPoints>();
    }

    public void SpawnAsteroid(int CountOfAsteroid, bool mySprite)
    {
        for (int i = 0; i < CountOfAsteroid; i++)
        {
            _numOfAsteroid = Random.Range(0, Asteroids.Length);
            var asteroid = Instantiate(Asteroids[_numOfAsteroid], _mySpawnPoints.SpawnPoint()[0], quaternion.identity) as GameObject;
            asteroid.GetComponent<ChangeToSprite>().SelectSprite = mySprite;
            asteroid.GetComponent<MyEnemy>().SizeAsteroid = _numOfAsteroid;
            asteroid.GetComponent<Rigidbody>().AddForce(_mySpawnPoints.SpawnPoint()[1] * 12f);
        }
    }

    public void SpawnUfo(bool mySprite)
    {
        var ufo = Instantiate(MyUfo, _mySpawnPoints.SpawnPoint()[0], quaternion.identity) as GameObject;
        ufo.GetComponent<ChangeToSprite>().SelectSprite = mySprite;
    }
}
