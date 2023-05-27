using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ia2 : MonoBehaviour
{
    [Header("References")] [SerializeField]
    private Transform player;
    [SerializeField] private Player playerDamage;

    [SerializeField] private NavMeshAgent agent;
   

    [Header("Stats")] [SerializeField] private float detectionRayon;
    [SerializeField] private float MaxHealth = 100f;
    [SerializeField] private float curentHealth;


    [SerializeField] private float attaqueRayon;
    [SerializeField] private float attaqueDelay;
    [SerializeField] private int Damage;


    [Header("Wandering parameters")] [SerializeField]
    private float wanderingTimeWaitMin;

    [SerializeField] private float wanderingTimeWaitMax;

    [SerializeField] private float wanderingDistanceMin;

    [SerializeField] private float wanderingDistanceMax;
    private bool balade;
    private bool IsAtacking;

    private void Awake()
    {
        curentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < detectionRayon)
        {
            if (!IsAtacking && curentHealth > 0)
            {
                if (Vector3.Distance(player.position, transform.position) < attaqueRayon)
                {
                    StartCoroutine(AttaquePlayer());
                }
                else
                {
                    agent.SetDestination(player.position);
                }
            }
        }
        else
        {
            if (!balade)
            {
                StartCoroutine(GetNewDestination());
            }
        }
    }

    IEnumerator GetNewDestination()
    {
        balade = true;
        yield return new WaitForSeconds(Random.Range(wanderingTimeWaitMin, wanderingTimeWaitMax));

        Vector3 nextDestination = transform.position;
        nextDestination += Random.Range(wanderingDistanceMin, wanderingDistanceMax) *
                           new Vector3(Random.Range(-1f, 1), 0f, Random.Range(-1f, 1f)).normalized;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, wanderingDistanceMax, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

        balade = false;

    }

    IEnumerator AttaquePlayer()
    {
        IsAtacking = true;
        agent.isStopped = true;
        playerDamage.TakeDamage(Damage);

        yield return new WaitForSeconds(attaqueDelay);
        agent.isStopped = false;
        IsAtacking = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRayon);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attaqueRayon);
    }

    public void TakeDamage2(float degats)
    {
        curentHealth -= degats;
    }

    public void Die()
    {
        curentHealth = 0;
    }
}
