using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] GameObject enemySpawnTextAnim = null;
    public void PlayEnemySpawnText()
    {
        enemySpawnTextAnim.GetComponent<Animator>().Play("EnemyText animation", 0);
    }
}
