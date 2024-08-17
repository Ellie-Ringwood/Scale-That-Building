using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move()
    {
        var x = 10;

        transform.Translate(x, 0, 0);
        Debug.Log("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);
    }
    void OnMove()
    {
        Debug.Log("Input");
    }
}
