using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class MyEnemy : MonoBehaviour
{
    public int SizeAsteroid;
    private GameManager _gameManager;
    

    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            _gameManager.ScoreIncrement();
            if (SizeAsteroid!=0)
            {
                for (int i = 0; i < 2; i++)
                {
                    var temp = Instantiate(_gameManager.GetComponent<SpawnEnemy>().Asteroids[SizeAsteroid - 1], gameObject.transform.position,
                        quaternion.identity) as GameObject;
                    var a = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0);
                    temp.GetComponent<Rigidbody>().AddForce(a.normalized*(100f/SizeAsteroid));
                    temp.GetComponent<MyEnemy>().SizeAsteroid = SizeAsteroid-1;
                }
            }
        }
    }
}
