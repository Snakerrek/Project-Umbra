using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] GameObject enemySpawnText = null;
    [SerializeField] GameObject enemyExplosion = null;
    [SerializeField] GameObject playerExplosion = null;
    [SerializeField] GameObject enemyLaserExplosion = null;
    [SerializeField] GameObject greenPlayerLaserExplosion = null;
    public void PlayEnemySpawnText()
    {
        enemySpawnText.GetComponent<Animator>().Play("EnemyText animation", 0);
    }

    public void PlayEnemyExplosion(Vector2 position)
    {
        var explosion = Instantiate(enemyExplosion, position, Quaternion.identity);
        explosion.transform.parent = gameObject.transform;
        Destroy(explosion, 2.0f);
    }

    public void PlayPlayerExplosion(Vector2 position)
    {
        var explosion = Instantiate(playerExplosion, position, Quaternion.identity);
        explosion.transform.parent = gameObject.transform;
        Destroy(explosion, 2.0f);
    }

    public void PlayEnemyLaserExplosion(Vector2 position)
    {
        var explosion = Instantiate(enemyLaserExplosion, position, Quaternion.identity);
        explosion.transform.parent = gameObject.transform;
        Destroy(explosion, 2.0f);
    }
    public void PlayGreenPlayerLaserExplosion(Vector2 position)
    {
        var explosion = Instantiate(greenPlayerLaserExplosion, position, Quaternion.identity);
        explosion.transform.parent = gameObject.transform;
        Destroy(explosion, 2.0f);
    }
}
