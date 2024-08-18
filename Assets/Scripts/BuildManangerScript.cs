using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManangerScript : MonoBehaviour
{
    public GameObject crate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void newObject()
    {
        Instantiate(crate, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
