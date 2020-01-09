using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSwitch : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    int count = 0;
    Vector3  left, right;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WhiteLight"))
        {
            count++;
            FindObjectOfType<AudioManager>().Play("DoorOpening");
            leftDoor.transform.eulerAngles = new Vector3(0, -count * 45, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, count * 45, 0);
            left = leftDoor.transform.eulerAngles;
            right = rightDoor.transform.eulerAngles;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WhiteLight"))
        {
            --count;
            FindObjectOfType<AudioManager>().Play("DoorClose");
            leftDoor.transform.eulerAngles = new Vector3(0, left.y + 45, 0);
            rightDoor.transform.eulerAngles = new Vector3(0, right.y - 45, 0);
        }
    }
}
