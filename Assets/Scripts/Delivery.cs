using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
   
{
    [SerializeField] float DestroyTime = 1f;
    bool Haspackage;
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Cargo" && Haspackage == false)
        {
            Destroy(other.gameObject, DestroyTime);
            Haspackage = true;
            
        }
        if (other.gameObject.tag == "Dp" && Haspackage == true) 
        {
            Haspackage = false;
            
        }
    }

}
