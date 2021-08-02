using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class UFO : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rb;

    private Vector3[] _direction;
    private Vector3 _randomVectorDirection;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _direction = new[] {Vector3.down, Vector3.left, Vector3.right, Vector3.up};
        var i = _direction[UnityEngine.Random.Range(0, _direction.Length)];
        _randomVectorDirection = transform.position - _direction[UnityEngine.Random.Range(0, _direction.Length)];
    }

    private void FixedUpdate()
    {
        MoveUfo();
    }

    private void MoveUfo()
    {
        if (_player!=null && Vector3.Distance(transform.position, _player.transform.position)<3f)
        {
            _rb.AddForce((_player.transform.position-transform.position).normalized*2f);
        }
        else
        {
            _rb.AddForce(_randomVectorDirection.normalized*1.5f);
        }
    }
}
