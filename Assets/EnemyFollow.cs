using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    private Transform player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        agent.SetDestination(player.position);
        float enemySpeed = agent.velocity.magnitude;
        anim.SetFloat("Blend", enemySpeed);
    }
}
