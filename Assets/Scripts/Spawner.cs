using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    bool spawn;
    
   
    
  

    public float timeToSpawn;
    private float currentTimetoSpawn;
    void Start()
    {
        currentTimetoSpawn = timeToSpawn;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimetoSpawn>0 && spawn == false)
        {
            currentTimetoSpawn -= Time.deltaTime;
            
        }
        else if (spawn == false)
        {
            SpawnObject();
           
            currentTimetoSpawn = timeToSpawn;
            spawn = true;
        }
    }
    public void SpawnObject()
    {
       
        Instantiate(objectToSpawn, transform.position = new Vector3(-4.5f,6f,transform.position.z), transform.rotation) ;

    
    }
  
  
    

}
