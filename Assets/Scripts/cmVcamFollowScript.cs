using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cmVcamFollowScript : MonoBehaviour
{
    private CinemachineVirtualCamera cm;

 [SerializeField] private Transform[] tr;
   PlaneSelector planeSelector;
   [SerializeField]  GameObject gameobject;
   
    private void Start()
    {
        planeSelector = gameobject.GetComponent<PlaneSelector>();
        
        cm = gameObject.GetComponent<CinemachineVirtualCamera>();
        cm.Priority = 1;
        foreach (var go in tr)
        {
            cm.Follow = go;
            cm.LookAt = go;
        }
      
    }
}
