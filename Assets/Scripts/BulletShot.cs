using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 10);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
