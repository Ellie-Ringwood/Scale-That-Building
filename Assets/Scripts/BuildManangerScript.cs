using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManangerScript : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject currentObject = null;

    private void Start()
    {
        newObject();
    }

    public void newObject()
    {
        int num = Random.Range(0, objects.Length);
        currentObject = Instantiate(objects[num], new Vector3(0, 0, 0), Quaternion.identity);
    }


    public void DestroyUnbuiltObject()
    {
        Destroy(currentObject);
    }
}
