using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralOfFire : MonoBehaviour
{
    [SerializeField] float spinSpeed = 1.0f;
    [SerializeField] float duration = 5.0f;

    Player player;
    Vector2 playerPos;
    bool increaseSize = true;
    float timeSinceStart = 0.0f;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        playerPos = player.transform.position;
        transform.position = playerPos;

        if (timeSinceStart > duration)
            StartCoroutine(Shrink());
        else
            StartCoroutine(changeSize());

        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meteorite")
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator changeSize()
    {
        yield return new WaitForSeconds(0.1f);
        if(increaseSize)
            transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
        else
            transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);

        if (transform.localScale.x >= 1.0f)
            increaseSize = false;
        if (transform.localScale.x <= 0.2f)
            increaseSize = true;
    }

    IEnumerator Shrink()
    {
        yield return new WaitForSeconds(0.1f);
        if(transform.localScale.x > 0.0f)
            transform.localScale -= new Vector3(0.005f, 0.005f, 0.005f);
        else
            Destroy(gameObject, 2.0f);
    }

}
