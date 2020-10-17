using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.WSA;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 2000.0f;
    [SerializeField] float lifespan = 3.0f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.AddForce(rb.transform.up * speed * Time.deltaTime);
        Destroy(gameObject, lifespan);
    }

}
