using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] GameObject indicator = null;
    [SerializeField] GameObject player = null;

    Camera cam;
    Transform target;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        target = gameObject.transform;
    }

    private void Update()
    {
        Point();
    }

    void Point()
    {
        if (IsVisible() == false)
        {
            indicator.transform.up = target.position - indicator.transform.position;

            if (indicator.activeSelf == false)
            {
                indicator.SetActive(true);
            }
            Vector2 direction = player.transform.position - target.position;

            RaycastHit2D ray = Physics2D.Raycast(target.position, direction);

            if (ray.collider.name == "CamBox")
            {
                indicator.transform.position = ray.point;
            }
        }
        else
        {
            if (indicator.activeSelf == true)
            {
                indicator.SetActive(false);
            }
        }
    }

    bool IsVisible()
    {
        Vector2 viewPos = cam.WorldToViewportPoint(target.position);
        if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1)
            return true;
        else
            return false;
    }
}
