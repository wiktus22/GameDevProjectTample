using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] Transform lLeftDoor;
    [SerializeField] Transform lRightDoor;
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;
    int count = 0;
    bool playerOnSwitch;
    Vector3 lleft, lright, left, right;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerOnSwitch();
            playerOnSwitch = true;
        }
         else if(other.gameObject.CompareTag("CanGrab"))
        {
            count++;
            if (playerOnSwitch == true)
            {
                PlayerOnSwitch();
            }
            else
            {
                leftDoor.transform.eulerAngles = new Vector3(0, 90 + (count * 15), 0);
                rightDoor.transform.eulerAngles = new Vector3(0, 90 - (count * 15), 0);
                lLeftDoor.transform.eulerAngles = new Vector3(0, 90 - (count * 15), 0);
                lRightDoor.transform.eulerAngles = new Vector3(0, 90 + (count * 15), 0);
                lleft = lLeftDoor.transform.eulerAngles;
                lright = lRightDoor.transform.eulerAngles;
                left = leftDoor.transform.eulerAngles;
                right = rightDoor.transform.eulerAngles;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnSwitch = false;
            if (count == 0)
            {
                leftDoor.transform.rotation = new Quaternion(0, 0, 0, 0);
                rightDoor.transform.rotation = new Quaternion(0, 0, 0, 0);
                lLeftDoor.transform.rotation = new Quaternion(0, 0, 0, 0);
                lRightDoor.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                leftDoor.transform.eulerAngles = new Vector3(0, left.y, 0);
                rightDoor.transform.eulerAngles = new Vector3(0, right.y, 0);
                lLeftDoor.transform.eulerAngles = new Vector3(0, lleft.y, 0);
                lRightDoor.transform.eulerAngles = new Vector3(0, lright.y, 0);
            }
        }
        else if (other.gameObject.CompareTag("CanGrab"))
        {
            count--;
            if (playerOnSwitch == true)
            {
                PlayerOnSwitch();
            }
            else
            {
                leftDoor.transform.eulerAngles = new Vector3(0, left.y - 15, 0);
                rightDoor.transform.eulerAngles = new Vector3(0, right.y + 15, 0);
                lLeftDoor.transform.eulerAngles = new Vector3(0, lleft.y + 15, 0);
                lRightDoor.transform.eulerAngles = new Vector3(0, lright.y - 15, 0);
            }
        }
    }
    void PlayerOnSwitch()
    {
        leftDoor.transform.rotation = new Quaternion(0, 0, 0, 90);
        rightDoor.transform.rotation = new Quaternion(0, 90, 0, 0);
        lLeftDoor.transform.rotation = new Quaternion(0, 0, 0, 90);
        lRightDoor.transform.rotation = new Quaternion(0, 90, 0, 0);
    }
}
