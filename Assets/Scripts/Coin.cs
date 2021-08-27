using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinEffect;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {

                PlayerMovement player = other.GetComponent<PlayerMovement>();

                if (player != null)
                {
                    player.hasCoin = true;
                    coinEffect.SetActive(true);
                    Destroy(this.gameObject);
                    UIManager uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
                    uiManager.CollecedCoins();
                    Debug.Log("Coin Collected");
                }
               

            }
        }
    }
}
