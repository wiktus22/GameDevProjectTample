using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOn : MonoBehaviour
{
    public GameObject panel;


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
    }
}
