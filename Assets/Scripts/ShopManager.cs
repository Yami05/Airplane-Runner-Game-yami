using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject[] planes;
    public int currentPlaneIndex;
    private void Start()
    {
        currentPlaneIndex = PlayerPrefs.GetInt("SelectedPlane", 0);
        foreach (GameObject plane in planes)
        {
            plane.SetActive(false);

            planes[currentPlaneIndex].SetActive(true);
        }
    }
    public void ChangeNext()
    {
        planes[currentPlaneIndex].SetActive(false);

        currentPlaneIndex++;
        if (currentPlaneIndex==planes.Length)
          currentPlaneIndex = 0;

            planes[currentPlaneIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedPlane", currentPlaneIndex);
    }
    public void ChangeBack()
    {
        planes[currentPlaneIndex].SetActive(false);

        currentPlaneIndex--;
        if (currentPlaneIndex == -1)
            currentPlaneIndex = planes.Length-1;

        planes[currentPlaneIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedPlane", currentPlaneIndex);
    }
}
