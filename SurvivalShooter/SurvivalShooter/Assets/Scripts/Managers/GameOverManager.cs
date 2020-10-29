using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
    public int deathcount;

    Animator anim;
	float restartTimer;


    void Awake()
    {
        deathcount = 0;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            
			restartTimer += Time.deltaTime;

            if ( restartTimer >= restartDelay) {

                if (deathcount >= 2 )
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
                
			}
        }
    }

   public void AddtoDeathCount()
    {
        deathcount += 1;
    }
}
