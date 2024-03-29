﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] float maxSpeed = 2.0f;
    [SerializeField] float force = 50.0f;

    [Header("Engines")]
    [SerializeField] ParticleSystem[] leftEngineParticles = null;
    [SerializeField] ParticleSystem[] rightEngineParticles = null;
    [SerializeField] ParticleSystem[] upEngineParticles = null;
    [SerializeField] ParticleSystem[] downEngineParticles = null;
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
            foreach(ParticleSystem particle in downEngineParticles)
                particle.Play();
        }
        else
            foreach (ParticleSystem particle in downEngineParticles)
                particle.Stop();

        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            rb2D.AddForce(new Vector2(0, -force * Time.deltaTime));
            foreach (ParticleSystem particle in upEngineParticles)
                particle.Play();
        }
        else
            foreach (ParticleSystem particle in upEngineParticles)
                particle.Stop();

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb2D.AddForce(new Vector2(-force * Time.deltaTime, 0));
            foreach (ParticleSystem particle in rightEngineParticles)
                particle.Play();
        }
        else
            foreach (ParticleSystem particle in rightEngineParticles)
                particle.Stop();
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb2D.AddForce(new Vector2(force * Time.deltaTime, 0));
            foreach (ParticleSystem particle in leftEngineParticles)
                particle.Play();
        }
        else
            foreach (ParticleSystem particle in leftEngineParticles)
                particle.Stop();

        rb2D.velocity = (Vector3.ClampMagnitude(rb2D.velocity, maxSpeed));
    }
}
