using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Coin coinscript;
    // Start is called before the first frame update
    void Start()
    {
        coinscript = gameObject.GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinscript.playerTransform.position, coinscript.moveSpeed * Time.deltaTime);
    }
  
}
