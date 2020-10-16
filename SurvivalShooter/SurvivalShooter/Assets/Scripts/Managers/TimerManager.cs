using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    public List<Timer> timers = new List<Timer>();
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Timer t in timers)
        {
            if (t.finished)
            {
                t.Update();
            }
           
        }
    }
}
public delegate void Timerfunction();



public class Timer
{
    public float duration = 1.0f;
    float elasped = 0.0f;

    public bool finished = false;
    public Timerfunction onTimer;

    public Timer(float d, Timerfunction t)
    {
        duration = d;
        onTimer = t;
    }

    public void Update()
    {
        elasped += Time.deltaTime;

        if (elasped >= duration && !finished)
        {
            finished = true;

            if (onTimer != null)
            {
                onTimer();
            }
        }

    }

}