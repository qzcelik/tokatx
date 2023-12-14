using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkPath : Enemy
{

    [SerializeField]
    List<GameObject> path;
    [SerializeField]
    float pathTime;
    int count = 1;
    [SerializeField]
    public Animator enemyAnimator;
    bool animCont = true;
    public static event Action<float> OnPlayerHealth;

    private void Start()
    {
        StartCoroutine(EnemyAnimation());
        StartCoroutine(WalkEnemyPointToPoint());
        enemyAnimator.SetTrigger("walk");
        OnPlayerHealth += PlayerHealthDown;
    }


    IEnumerator EnemyAnimation()
    {
        while (animCont)
        {
            if (enemyBehaviour == EnemyBehaviour.died)
            {
                animCont = false;
                break;
            }
            var animatorStateInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.IsName("walk") && animatorStateInfo.normalizedTime >= 1.0f)
            {
                enemyAnimator.SetTrigger("walk");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator WalkEnemyPointToPoint()
    {
        while (animCont)
        {
            float distance = DistancePlayerAndEnemy();

            if (distance < (float)PlayerDistaceControl.longDistance)
            {
                StartCoroutine(FollowToPlayer(0.5f));
                Debug.Log("follow");
                break;
            }

            LeanTween.move(gameObject, path[count].transform, pathTime).setOnComplete(x => { });
            gameObject.transform.LookAt(path[count].transform);

            yield return new WaitForSeconds(pathTime);

            if (count < path.Count - 1)
            {
                count++;
            }
            else
            {
                count = 0;
            }
        }
    }

    private IEnumerator FollowToPlayer(float time)
    {
        while (animCont)
        {
            enemyAnimator.SetTrigger("punch");
            //AttackToPlayer(GameObject.CreatePrimitive(PrimitiveType.Capsule));
            FollowPlayer();
            yield return new WaitForSeconds(time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("Player"))
        {
            OnPlayerHealth.Invoke(5);
        }
    }



}
