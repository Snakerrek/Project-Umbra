using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_right : MonoBehaviour
{
    [SerializeField] ParticleSystem fire;
    void Start()
    {
        fire.Stop();
    }
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a"))
            fire.Play();
        else
            fire.Stop();
    }
}
