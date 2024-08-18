using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PreviewObject : MonoBehaviour
{
    public bool moveable = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            moveable = false;
            this.tag = "Untagged";
        }
    }
}
