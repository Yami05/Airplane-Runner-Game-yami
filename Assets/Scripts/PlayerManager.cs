using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
   public static int coinCount;
    public static float m;
    public Text coinstext;
    public Text movement;
    bool ended;

    
    // Start is called before the first frame update
    void Start()
    {
        ended = false;
      coinCount=  PlayerPrefs.GetInt("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        coinstext.text = "Coins:" + coinCount;
        movement.text = " "+  m;
        PlayerPrefs.SetInt("Coin",coinCount);
    }
    public void endgame()
    {
       
        SceneManager.LoadScene(1);
    }
}
