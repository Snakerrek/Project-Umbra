using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.5f;
    [SerializeField] Material bgMaterial;

    Vector2 offset;
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(scrollSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        bgMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
