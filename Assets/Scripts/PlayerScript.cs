using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float rotateSpeed = 0.4f;
    public float moveSpeed = 0.06f;
    public void Awake()
    {
        
    }

    //public Vector3 Position = new NetworkVariable<Vector3>();
    public void Move()
    {
       
        //Position.Value = transform.position;

    }
    void Update()
    {
        //var x = Input.GetAxis("Horizontal") * 0.1f;
       //var z = Input.GetAxis("Vertical") * 0.1f;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(x, 0, z);
            transform.position += transform.forward * moveSpeed;
           // transform.Translate(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * moveSpeed;
        }

        //transform.position = Position.Value;
    }
}
