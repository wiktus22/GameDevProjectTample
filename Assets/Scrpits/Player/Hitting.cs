using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
        return null;
    }
    bool CanDestroy(GameObject candidate)
    {
        return candidate.gameObject.tag == "CanGrab";
    }
    void TryDestroyObject(GameObject hittedObject)
    {
        if (!CanDestroy(hittedObject))
            return;
        FindObjectOfType<AudioManager>().Play("Vase");
        Destroy(hittedObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TryDestroyObject(GetMouseHoverObject(2));
    }
}
