using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits_tester : MonoBehaviour {

	public GameObject[] fruits;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
		fruits[6].transform.RotateAround (Vector3.up, Time.deltaTime);
		
	
	}
}
