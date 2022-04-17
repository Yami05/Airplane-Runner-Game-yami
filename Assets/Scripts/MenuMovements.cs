using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovements : MonoBehaviour
{

   public GameObject[] clouds;
    public GameObject[] baloons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        foreach (var g in baloons )
        {
            g.transform.Translate(0, 10 * Time.deltaTime, 0);
        }
        foreach (var cloud in clouds)
        {
            cloud.transform.Translate(10 * Time.deltaTime, 0, 0);
        }
    }
}
