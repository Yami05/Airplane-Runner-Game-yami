using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelector : MonoBehaviour
{
    public GameObject[] planess;
    public int currentPlaneIndex;
    private void Start()
    {
        currentPlaneIndex = PlayerPrefs.GetInt("SelectedPlane", 0);
        foreach (GameObject plane in planess)
        {
            plane.SetActive(false);

            planess[currentPlaneIndex].SetActive(true);
        }
    }
}