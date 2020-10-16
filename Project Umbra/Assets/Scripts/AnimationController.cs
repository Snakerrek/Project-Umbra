using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] GameObject enemySpawnText = null;
    public void PlayEnemySpawnText()
    {
        enemySpawnText.GetComponent<Animator>().Play("EnemyText animation", 0);
    }
}
