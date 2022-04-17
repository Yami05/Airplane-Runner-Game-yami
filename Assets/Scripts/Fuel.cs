using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
   public  int currentFuel = 100;
    bool moving = true;
    float countDown ;
     public float multiplier = 1f ;
  PlaneMovement planeMovement;
    [SerializeField]  GameObject player;
    public FuelUI fuelui;
    

    // Start is called before the first frame update
    void Start()
    {
        planeMovement = player.GetComponent<PlaneMovement>();
        
        countDown = multiplier;
        fuelui.SetMaxFuel(currentFuel);
    }

    // Update is called once per frame
    void Update()
    { 
       
        if (moving)
        {
            if (countDown>0f) 
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = multiplier;
                currentFuel -= 1;
                fuelui.SetFuel(currentFuel);
            }
            if (currentFuel <= 0)
            {
             
                
                multiplier = 100f;
                planeMovement.zerofuel = -1f *Time.deltaTime;
                gameObject.GetComponent<Rigidbody>().useGravity = true;


            }
            if (currentFuel >= 100)
            {
                currentFuel = 100;
            }
            if (currentFuel <=0)
            {
                currentFuel = 0;
            }


        }
    }
}
