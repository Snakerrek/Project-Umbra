using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_down : MonoBehaviour
{
    [SerializeField] ParticleSystem fire;
    void Start()
    {
        fire.Stop();
    }
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
            fire.Play();
        else
            fire.Stop();
    }
}
