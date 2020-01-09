using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSwitch : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedLight"))
        {
            count++;
            FindObjectOfType<AudioManager>().Play("DoorOpening");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RedLight"))
        {
            count--;
            FindObjectOfType<AudioManager>().Play("DoorClose");
        }
    }
    private void Update()
    {
        if (count == 4)
        {
            
            leftDoor.transform.eulerAngles = new Vector3(0, 180, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(count != 4)
        {
            leftDoor.transform.eulerAngles = new Vector3(0, 90, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
}
