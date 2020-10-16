using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timertest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Timer myTimer1 = new Timer(1.0f, print);

        TimerManager.Instance.timers.Add(myTimer1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void print()
    {
        Debug.Log("hello world");
    }
}
