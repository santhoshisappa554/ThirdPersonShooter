using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShop : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("E");
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                if (player != null)
                {
                    if (player.hasCoin == true)
                    {
                        player.hasCoin = false;
                        UIManager uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
                        if (uIManager != null)
                        {
                            uIManager.RemovedCoins();

                        }
                        player.EnableWeapon();
                        
                       
                    }
                   
                }
                
            }
           
        }
        else
        {
            print("Please go collect the coin");
        }
    }
}
