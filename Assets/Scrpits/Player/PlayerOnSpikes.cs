using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnSpikes : MonoBehaviour
{
        void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.CompareTag("Player"))
            FindObjectOfType<GameManager>().Dead();
        else Destroy(other.gameObject);
        }
}
