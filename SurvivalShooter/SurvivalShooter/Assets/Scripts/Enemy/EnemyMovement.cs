using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    Transform player, player2;
    Transform self;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    GameObject[] players;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }


    void Update()
    {
        
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {

            
            if (players[0].transform.position.magnitude > players[1].transform.position.magnitude)
            {
                nav.SetDestination(players[1].transform.position);
            }
            else { nav.SetDestination(players[0].transform.position); }


        }
    

        else
        {
            nav.enabled = false;
        }
    }
}
