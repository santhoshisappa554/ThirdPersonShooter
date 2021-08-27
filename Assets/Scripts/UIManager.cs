using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private GameObject coins;
    public void Updateammo(int count)
    {
        ammoText.text = "Current Bullets: "+count;
    }

    public void CollecedCoins()
    {
        coins.SetActive(true);
    }
    public void RemovedCoins()
    {
        coins.SetActive(false);
    }
}
