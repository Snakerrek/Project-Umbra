using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject barrel;
    [SerializeField] GameObject projectilePrefab;
    void Update()
    {
        FaceMouse();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );

        transform.up = direction;
    }
    void Shoot()
    {
        Vector2 position = new Vector2(barrel.transform.position.x, barrel.transform.position.y);
        Instantiate(projectilePrefab, position, transform.rotation);

    }
}
