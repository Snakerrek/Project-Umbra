using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject barrel = null;
    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] float timeBetweenShots = 0.4f;
    bool canShoot = true;
    void Update()
    {
        FaceMouse();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(canShoot)
                StartCoroutine(Shoot());
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
    IEnumerator Shoot()
    {
        canShoot = false;
        Vector2 position = new Vector2(barrel.transform.position.x, barrel.transform.position.y);
        Instantiate(projectilePrefab, position, transform.rotation);
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
}
