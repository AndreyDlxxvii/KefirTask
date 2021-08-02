using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    private GameManager _gameManager;
  
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        RotateShip();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void RotateShip()
    {
        Vector3 rot = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotate);
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _rb.AddForce(Vector3.up.normalized * moveVertical);
        _rb.AddForce(Vector3.right.normalized * moveHorizontal);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _gameManager.EndGame();
            Destroy(gameObject);
        }
    }
}

