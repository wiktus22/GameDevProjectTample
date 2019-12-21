using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    GameObject grabbedObject;
    float grabbedObjectSize;
    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
        return null;
    }
    void TryGrabObject(GameObject grabObject)
    {
        if(grabObject == null || !CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
        grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude + 2f;
    }
    bool CanGrab(GameObject candidate)
    {
        return candidate.gameObject.tag == "CanGrab"; 
    }
    void DropObject()
    {
        if (grabbedObject == null)
            return;
        grabbedObject = null;
        if (gameObject.CompareTag("CanGrab"))
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(2));
            else
                DropObject();
        }
        if (grabbedObject != null)
        {
            Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPosition;
        }
    }
}
