using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOp : MonoBehaviour
{
    public static HitOp instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (PlayerMovement.Instance.shot == true)
        {
            StartCoroutine("Couroutine");
        }
        
    }
   
    

    IEnumerator Couroutine()
    {
        yield return new WaitForSeconds(1);
        if (gameObject.name == "Hit_Marker")
        {
            print("Coroutine called");
            PlayerMovement.Instance.AddtoHitPrefabPool(this.gameObject);
        }
    }

   
}
