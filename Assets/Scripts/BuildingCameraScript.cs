using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCameraScript : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    public float moveSpeed = 0.06f;


    void changeCams()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, moveSpeed, 0);
            float posY = transform.position.y;
            posY = Mathf.Clamp(posY, 0f, 35f);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -moveSpeed, 0);
            float posY = transform.position.y;
            posY = Mathf.Clamp(posY, 0f, 35f);
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }

    }


}
