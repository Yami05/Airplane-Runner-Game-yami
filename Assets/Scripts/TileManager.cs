using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public float zSpawn =0;
    public float tileLenght = 50f;
    private int numberOfTiles= 5;
    public Transform playerTransform;
    private List<GameObject> activetiles = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i <numberOfTiles ; i++)
        {
            if (i==0)
            {
                SpawnTile(0);
            }
            else
            SpawnTile(Random.Range(0, levelPrefabs.Length));
        }
        
    }

    
    void Update()
    {
        if (playerTransform.position.z-40 >zSpawn-(numberOfTiles*tileLenght))
        {
            SpawnTile(Random.Range(0, levelPrefabs.Length));
            deleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
     GameObject go=   Instantiate(levelPrefabs[tileIndex], transform.forward*zSpawn, Quaternion.identity);
        activetiles.Add(go);
        zSpawn += tileLenght;
    }
   private void deleteTile()
    {
        Destroy(activetiles[0]);
        activetiles.RemoveAt(0);
    }
}
