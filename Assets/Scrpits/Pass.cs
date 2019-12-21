using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    public Collider corridorBlock;
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            corridorBlock.isTrigger = true;
        }
        else corridorBlock.isTrigger = false;
    }

}
