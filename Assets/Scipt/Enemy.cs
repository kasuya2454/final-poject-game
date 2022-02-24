using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private float hpmummy = 500f;
    private float distance;
    [SerializeField] private float maxFollowDistance = 20f;
    [SerializeField] private float distanceToStop = 4f;
    [SerializeField] private bool isWalk = false;
    [SerializeField] private bool isDie = false;
    [SerializeField] private bool isAttack = false;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private Material material;
    public bool PlayerAttack = false;
    private bool checkDamageScreen = false;
    public static Enemy instance;
    private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
       instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpmummy > 0)
        {
            Seeking();
        }
        else
        {
            Dead();
        }

        enemyAnimator.SetBool("isWalk", isWalk);
        enemyAnimator.SetBool("isDie", isDie);
        enemyAnimator.SetBool("isAttack", isAttack);
    }
    void Seeking()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > distanceToStop && distance < maxFollowDistance)
        {
            navMesh.SetDestination(player.transform.position);
            isWalk = true;
            isAttack = false;
        }
        else
        {
            navMesh.SetDestination(transform.position);
            isWalk = false;
            if (distance < distanceToStop)
            {
                Attack();
                isAttack = true;
               /* if (checkDamageScreen == false)
                {
                    StartCoroutine(delayDamageScreen());
                }*/
            }
        }
    }
    void Dead()
    {
        if (hpmummy < 1)
        {
            navMesh.isStopped = true;
            isDie = true;
            StartCoroutine(delayDead());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon") && PlayerAttack == true)
        {
            hpmummy -= 10;

            if (hpmummy > 0)
            {
                //enemyAnimator.Play("takeDamage");
                StartCoroutine(flashEnemy());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerAttack = false;
    }

    IEnumerator delayDead()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    IEnumerator flashEnemy()
    {
        for (int i = 0; i < 2; i++)

        {
            material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Attack()
    {
        
            yield return new WaitForSeconds(0.5f);
        
    }
    /*IEnumerator delayDamageScreen()
    {
        checkDamageScreen = true; ;
        yield return new WaitForSeconds(0.5f);
        Hpbar.instance.DamagePlayer(10);
        yield return new WaitForSeconds(2f);
        checkDamageScreen = false;
    }*/
}

