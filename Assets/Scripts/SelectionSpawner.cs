using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSpawner : MonoBehaviour
{
    bool spawn;

    public GameObject[] selections13;
    public GameObject[] selections17;
   
    

    public float timeToSpawn;
    private float currentTimetoSpawn;
    void Start()
    {
        currentTimetoSpawn = timeToSpawn;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimetoSpawn > 0 && spawn == false)
        {
            currentTimetoSpawn -= Time.deltaTime;

        }
        else if (spawn == false)
        {
            SSo();
            currentTimetoSpawn = timeToSpawn;
            spawn = true;
        }
    }
   
    public void SSo()
    {
        Instantiate(selections13[Random.Range(0, selections13.Length)], transform.position = new Vector3(0, 13f, transform.position.z), transform.rotation);
        Instantiate(selections17[Random.Range(0, selections17.Length)], transform.position = new Vector3(0, 17.5f, transform.position.z), transform.rotation);
    }
  
}
