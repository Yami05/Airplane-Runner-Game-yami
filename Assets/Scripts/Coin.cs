using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public Transform playerTransform;

    public float moveSpeed = 17f;
    public float Timer;
    CoinMove coinmove;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinmove = gameObject.GetComponent<CoinMove>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(30 * Time.deltaTime, 0, 0);
      
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            PlayerManager.coinCount++;
            Destroy(gameObject);
            
        }

        if (other.gameObject.tag == "CoinDetector")
        {
            coinmove.enabled = true;
        }
       
    }
}
