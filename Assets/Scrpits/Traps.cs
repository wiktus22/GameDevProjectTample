using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (true)
        {
           // FindObjectOfType<AudioManager>().Play("Spikes");
            GetComponent<Animation>().Play();
            yield return new WaitForSeconds(3f);
        }
    }
}
