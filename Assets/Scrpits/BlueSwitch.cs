using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSwitch : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    int count = 0;
    Vector3 left, right;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueLight"))
        {
            count++;
            FindObjectOfType<AudioManager>().Play("DoorOpening");
            
            
            left = leftDoor.transform.eulerAngles;
            right = rightDoor.transform.eulerAngles;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BlueLight"))
        {
            --count;
            FindObjectOfType<AudioManager>().Play("DoorClose");
            
        }
    }
    private void Update()
    {
        if (count != 3)
        {
            leftDoor.transform.eulerAngles = new Vector3(0, 0, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, 0, 0);
        } else
        {
            leftDoor.transform.eulerAngles = new Vector3(0, -90, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
}
