using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPoints : MonoBehaviour
{
    private Vector2 SpawnUpL;
    private Vector2 SpawnUpR;
    private Vector2 SpawnDownL;
    private Vector2 SpawnDownR;
    
    private Vector2 _direction;
    private int _numberOfSpawn;

    private Vector2[] SpawnDirection;

    private void Start()
    {
        SpawnDirection = new Vector2[2];
        SpawnUpL = Camera.main.ScreenToWorldPoint(new Vector2 (0, Camera.main.pixelHeight));
        SpawnUpR = Camera.main.ScreenToWorldPoint(new Vector2 (Camera.main.pixelWidth, Camera.main.pixelHeight));
        SpawnDownL = Camera.main.ScreenToWorldPoint(new Vector2 (0, 0));
        SpawnDownR = Camera.main.ScreenToWorldPoint(new Vector2 (Camera.main.pixelWidth, 0));
        
    }

    public Vector2 [] SpawnPoint()
    {
        Vector2 pointFirst = new Vector2(((Vector2.Distance(SpawnUpL,SpawnUpR)/Random.Range(4f,5f)) * Random.Range(-1,2)),5f);
        Vector2 pointSecond = new Vector2(((Vector2.Distance(SpawnDownL,SpawnDownR)/Random.Range(4f,5f)) * Random.Range(-1,2)),-5f);
        Vector2 pointThird = new Vector2(-8.8f,((Vector2.Distance(SpawnUpL,SpawnDownL)/Random.Range(4f,5f))* Random.Range(-1,2)));
        Vector2 pointFourth = new Vector2(8.8f, ((Vector2.Distance(SpawnUpR,SpawnDownR)/Random.Range(4f,5f))* Random.Range(-1,2)));
        Vector2[] pull = new[] {pointFirst, pointSecond, pointThird, pointFourth};
        _numberOfSpawn = Random.Range(0, pull.Length);
        switch (_numberOfSpawn)
        {
            case 0:
                _direction = pointSecond - pointThird;
                break;
            case 1:
                _direction = pointFirst - pointFourth;
                break;
            case 2:
                _direction = pointFourth - pointSecond;
                break;
            case 3:
                _direction = pointThird - pointFirst;
                break;
        }
        //спавн из рандовной точки
        SpawnDirection[0] = pull[_numberOfSpawn];
        //спавн по рандомному направлению
        SpawnDirection[1] = _direction;
        return SpawnDirection;
    }
}
