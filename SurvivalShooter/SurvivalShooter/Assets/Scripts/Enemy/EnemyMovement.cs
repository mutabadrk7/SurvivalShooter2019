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
    public GameObject[] players;
    public int deathcount = 0;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");
        //deathcount = GetComponent<GameOverManager>(deathcount);
            ;
        for (int i = 0; i < players.Length; i++)
        {
            playerHealth = players[i].GetComponent<PlayerHealth>();
        }

        
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }


    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {

            if (deathcount < 1)
            {


                if (players[0].transform.position.magnitude > players[1].transform.position.magnitude)
                {
                    nav.SetDestination(players[1].transform.position);
                }
                else { nav.SetDestination(players[0].transform.position); }
            }
            //else
            //{

               
            //        nav.SetDestination(players[0].transform.position);
                

               

            //}

        }
    

        else
        {
            nav.enabled = false;
        }
    }
}
