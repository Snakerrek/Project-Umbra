using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine_up : MonoBehaviour
{
    [SerializeField] ParticleSystem fire;
    void Start()
    {
        fire.Stop();
    }
    void Update()
    {
        if (Input.GetKey("down") || Input.GetKey("s"))
            fire.Play();
        else
            fire.Stop();
    }
}
