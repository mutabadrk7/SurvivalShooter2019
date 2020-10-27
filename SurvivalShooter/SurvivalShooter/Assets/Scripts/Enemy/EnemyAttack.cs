using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject[] players;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake ()
    {
       // player = GameObject.FindGameObjectWithTag ("Player" );
        players = GameObject.FindGameObjectsWithTag("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            players = GameObject.FindGameObjectsWithTag("Player");
            if (players[0].transform.position.magnitude > players[1].transform.position.magnitude)
            {
                player = players[1];
            }
            else { player = players[0]; }
            playerHealth = player.GetComponent<PlayerHealth>();
           // Update();
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            //if (players[0].transform.position.magnitude > players[1].transform.position.magnitude)
            //{
            //    player = players[1];
            //}
            //else { player = players[0]; }
            playerHealth = player.GetComponent<PlayerHealth>();
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        enemyHealth = GetComponent<EnemyHealth>();

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }


    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
           playerHealth.TakeDamage (attackDamage);
        }
    }
}
