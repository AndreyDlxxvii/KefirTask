using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFireShot : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private GameManager _gameManager;
    private float _reloadTimeLaser;
    
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject GunPoint;
    
    private void Awake()
    {
        _lineRenderer = GunPoint.GetComponent<LineRenderer>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
       Fire();
    }
    
    private void Fire()
    {
        _reloadTimeLaser += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, GunPoint.transform.position,GunPoint.transform.rotation);
        }

        if (Input.GetButton("Fire2") && _reloadTimeLaser > 1f)
        {
            StartCoroutine (ShotEffect());
            MyLaser();
            _reloadTimeLaser = 0f;
        }
    }
    
    private void MyLaser()
    {
        var position = GunPoint.transform.position;
        var target = new Vector2(position.x, position.y) +
                     (GetRotationVector() * 100f);
        DrawLaser(position, target);
        RaycastHit[] raycastHit = Physics.RaycastAll(new Ray(position, GunPoint.transform.right), 50f, 8);
        foreach (var ell in raycastHit)
        {
            if (ell.transform != null)
            {
                Destroy(ell.transform.gameObject);
                _gameManager.ScoreIncrement();
            }
        }
    }

    private void DrawLaser(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }

    private Vector2 GetRotationVector()
    {
        return transform.rotation * Vector2.right;
    }

    IEnumerator ShotEffect()
    {
        _lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.2f);
        _lineRenderer.enabled = false;
    }
}
