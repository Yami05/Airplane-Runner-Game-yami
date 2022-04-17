using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public GameObject coinDetectorObj;


    private void Start()
    {

        coinDetectorObj.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            StartCoroutine(ActivateCoin());
            
        }
       
    }
    IEnumerator ActivateCoin()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(4f);
        coinDetectorObj.SetActive(false);
    }
}
