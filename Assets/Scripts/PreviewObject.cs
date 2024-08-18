using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PreviewObject : MonoBehaviour
{
    public bool moveable = true;
    public Material placedMaterial;
    public GameObject buildManager;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = GameObject.FindGameObjectWithTag("BuildManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable)
        {
            Vector3 mouse = Input.mousePosition;
            Ray casepoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(casepoint, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag != "PreviewObject") { 
                    transform.position = new Vector3(hit.point.x+hit.normal.x, hit.point.y + hit.normal.y, hit.point.z + hit.normal.z);
                    // if (Input.GetKeyDown(KeyCode.E))
                    if (Input.GetMouseButton(1))
                    {
                        Debug.Log("E");
                        Debug.Log("x: "+hit.normal.x+"z: " + hit.normal.z);
                        transform.Rotate(hit.normal.x, hit.normal.y, hit.normal.z);
                       /* if (hit.normal.x == 0) // start wall, z change
                        {
                            transform.eulerAngles = new Vector3(0, 0, transform.rotation.z);
                            //transform.eulerAngles.x = 0;
                        }
                        if (hit.normal.z == 0)
                        {
                            transform.eulerAngles = new Vector3(transform.rotation.x, 0, 0);
                            //transform.eulerAngles.x = 0;
                        }*/

                    }
                }
            }
            
        }
        if ((Input.GetMouseButtonDown(0))&&(moveable == true))
        {
            GetComponent<MeshRenderer>().material = placedMaterial;
            moveable = false;
            this.tag = "Untagged";
            //new WaitForSeconds(1);
            buildManager.GetComponent<BuildManangerScript>().newObject();
        }
    }
}
