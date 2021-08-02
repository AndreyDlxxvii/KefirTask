using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToSprite : MonoBehaviour
{
    public bool SelectSprite;
    
    private GameManager _gameManager;
    private List<MeshRenderer> _meshRenderers = new List<MeshRenderer>();
    private List<SpriteRenderer> _spriteRenderers = new List<SpriteRenderer>();

    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        AddListProperties();
    }

    private void Start()
    {
        SelectSprite = _gameManager.MySprite;
        ChangeSpriteMesh(SelectSprite);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectSprite = _gameManager.MySprite;
            ChangeSpriteMesh(SelectSprite);
        }
    }

    public void ChangeSpriteMesh(bool _myFlag)
    {

        foreach (var ell in _meshRenderers)
        {
            ell.enabled = _myFlag;
        }

        foreach (var ell in _spriteRenderers)
        {
            ell.enabled = !_myFlag;
        }
    }

    private void AddListProperties()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<MeshRenderer>())
            {
                _meshRenderers.Add(child.GetComponent<MeshRenderer>());
            }

            if (child.GetComponent<SpriteRenderer>())
            {
                _spriteRenderers.Add(child.GetComponent<SpriteRenderer>());
            }
        }
    }
}
