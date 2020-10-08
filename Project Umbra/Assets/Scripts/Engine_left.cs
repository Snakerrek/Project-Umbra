using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_left : MonoBehaviour
{
    [SerializeField] ParticleSystem fire;
    void Start()
    {
        fire.Stop();
    }
    void Update()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
            fire.Play();
        else
            fire.Stop();
    }
}
