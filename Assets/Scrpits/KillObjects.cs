using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            FindObjectOfType<GameManager>().Dead();
        else if(other.gameObject.CompareTag("CanGrab")) Destroy(gameObject);
    }
}
