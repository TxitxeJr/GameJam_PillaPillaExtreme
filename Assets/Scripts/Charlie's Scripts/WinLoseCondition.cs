using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    public Counter counter;
    public timeManager time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter.counter == 0)
        {
            SceneManager.LoadScene("Win");
        }
        if(time.startingTime <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
