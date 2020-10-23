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


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        

        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            if ( player.position.magnitude > player2.position.magnitude  )
            {
                nav.SetDestination(player2.position);
            }
            else { nav.SetDestination (player.position);}
            
        }
        else
        {
            nav.enabled = false;
        }
    }
}
