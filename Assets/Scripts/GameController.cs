using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float targetTime = 10.0f;
    public float timer;
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        countdown = targetTime - timer;
         
        if (countdown <= 0)
        {
            timerEnded();
        }
    }

    public void SinglePlayer()
    {
        Debug.Log("single player");
        SceneManager.LoadScene(1);
    }

    public void MultiPlayer()
    {
        Debug.Log("multiplayer");
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void timerEnded()
    {
        Debug.Log("end");
        //do your stuff here.
    }
}
