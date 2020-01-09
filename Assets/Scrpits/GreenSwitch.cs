using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSwitch : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    int count = 0;
    Vector3 left, right;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenLight"))
        {
            count++;
            FindObjectOfType<AudioManager>().Play("DoorOpening");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GreenLight"))
        {
            count--;
            FindObjectOfType<AudioManager>().Play("DoorClose");
            
        }
    }
    private void Update()
    {
        
            leftDoor.transform.eulerAngles = new Vector3(0, -count * 18, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, count * 18, 0);
        
    }
}
