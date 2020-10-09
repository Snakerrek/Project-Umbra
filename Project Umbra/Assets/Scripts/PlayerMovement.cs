using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] float maxSpeed = 2.0f;
    [SerializeField] float force = 50.0f;

    [Header("Engines")]
    [SerializeField] ParticleSystem leftEngineParticles = null;
    [SerializeField] ParticleSystem rightEngineParticles = null;
    [SerializeField] ParticleSystem upEngineParticles = null;
    [SerializeField] ParticleSystem downEngineParticles = null;
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            rb2D.AddForce(new Vector2(0, force * Time.deltaTime));
            downEngineParticles.Play();
        }
        else
            downEngineParticles.Stop();

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            rb2D.AddForce(new Vector2(0, -force * Time.deltaTime));
            upEngineParticles.Play();
        }
        else
            upEngineParticles.Stop();

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb2D.AddForce(new Vector2(-force * Time.deltaTime, 0));
            rightEngineParticles.Play();
        }
        else
            rightEngineParticles.Stop();
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(force * Time.deltaTime, 0));
            leftEngineParticles.Play();
        }
        else
            leftEngineParticles.Stop();

        rb2D.velocity = (Vector3.ClampMagnitude(rb2D.velocity, maxSpeed));
    }
}
