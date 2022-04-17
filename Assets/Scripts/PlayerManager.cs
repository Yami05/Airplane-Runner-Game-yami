using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
   public static int coinCount;
    public static float m;
    public Text coinstext;
    public Text movement;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
      coinCount=  PlayerPrefs.GetInt("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        coinstext.text = "Coins:" + coinCount;
        movement.text = " "+  m;
        PlayerPrefs.SetInt("Coin",coinCount);
    }
}
