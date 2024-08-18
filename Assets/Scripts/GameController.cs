using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float buildTime = 10.0f;
    private float playTime = 60.0f;
    public float timer;
    public float countdown;
    public bool buildPhase = true;
    public GameObject buildingCamera;
    public GameObject buildManager;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (buildPhase)
        {
            countdown = buildTime - timer;
        }
        else
        {
            countdown = playTime - timer;
        }
         
        if (countdown < 0)
        {
            if (buildPhase)
            {
                timerEnded();
            }
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
        Vector3 v = new Vector3(40, 1, 40);
        GameObject newPlayer = Instantiate(player, v, Quaternion.identity) as GameObject;
        newPlayer.transform.position = v;
        timer = 0;
        buildPhase = false;
        buildingCamera.SetActive(false);
        //buildingCamera.GetComponent<BuildingCameraScript>().changeCam();
        buildManager.GetComponent<BuildManangerScript>().DestroyUnbuiltObject();
        
    }
}
