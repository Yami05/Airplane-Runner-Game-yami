using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
   
    private Vector3 direction;
  
   public float boostspeed ;
   
    public float zerofuel = 0f;
    public float forwardSpeed;
    private int desiredLane = 1; 
    public float laneDistance = 4;  
    public float jumpForce;
    public float a ;
    public float b;
   
    Fuel fuel;
    [SerializeField] GameObject player;
    [SerializeField] GameObject go;


    void Start()
    {


        fuel = player.GetComponent<Fuel>();
        b = a + 2;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boost")
        {
            StartCoroutine(BackToNormalSpeed());
           
            
        }
       
        if (other.tag == "fuelup" && fuel.currentFuel < 100f)
        {
            fuel.currentFuel += 50;
            
        }
        if (other.tag =="Choice")
        {

            a = 5;
            b = 5;
        }if (other.tag =="Choice1")
        {

            a = 5;
            b = 5;
        }if (other.tag =="Choice2")
        {

            a = 8;
            b = 8;
        }
        if (other.tag =="Choice3")
        {

            a = 10;
            b = 10;
        }

        if (other.tag == "Choice4")
        {

            a = 10;
            b = 10;
        }
        if (other.tag == "+2")
        {
            a = b;
        }
        else
        {
            
        }
        
        
        if (other.tag =="Coin")
        {
            Destroy(go, 0.2f);
        }




    }

   

   IEnumerator BackToNormalSpeed()
    {
        forwardSpeed = boostspeed;
        yield return new WaitForSeconds(9f);
        forwardSpeed = 10;
    }




    
    
    

  
    void FixedUpdate()
    {

        

    }
    void Update()
    {
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

        PlayerManager.m = a;

        if (SwipeManager.swipeUp && a > 0 )
        {
            transform.position = new Vector3(transform.position.x, 17, transform.position.z);
            a--;
        }
        if (SwipeManager.swipeDown && a > 0)
        {
            a--;
            transform.position = new Vector3(transform.position.x, 13, transform.position.z);
        }
    
        if (SwipeManager.swipeRight && a > 0)
        {
            a--;
            desiredLane++;
            if (desiredLane == 3)
                
            desiredLane = 2;


        }
        if (SwipeManager.swipeLeft && a > 0)
        {
            a--;
            desiredLane--;
            if (desiredLane == -1)

               

            desiredLane = 0;
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        
        





        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.fixedDeltaTime);
    }
    private void jump()
    {
        direction.y = jumpForce * Time.deltaTime;
    }
    private void jumpdown ()
    {
        direction.y = -jumpForce*Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<PlayerManager>().endgame();

    }

}
    


        
          

                

            
        
    

