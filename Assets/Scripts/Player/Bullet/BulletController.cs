using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletController : MonoBehaviour
{


    private void Start()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("enemy"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.health -= 10;
            //enemy.healthSlider.value = enemy.health;

            enemy.bloodEffect.Play();


            if (enemy.health <= 0)
            {
                other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                if (other.gameObject.GetComponent<EnemyController>())
                {
                    other.gameObject.GetComponent<EnemyController>().enemyBehaviour = Enemy.EnemyBehaviour.died;
                    other.gameObject.GetComponent<EnemyController>().enemyAnimator.SetTrigger("death");
                }

                if (other.gameObject.GetComponent<EnemyWalkPath>())
                {
                    other.gameObject.GetComponent<EnemyWalkPath>().enemyBehaviour = Enemy.EnemyBehaviour.died;
                    other.gameObject.GetComponent<EnemyWalkPath>().enemyAnimator.SetTrigger("death");
                }
            }
        }
    }


}
