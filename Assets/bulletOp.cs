using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletOp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = WeaponShotpos.instance.transform.rotation;
        if (Bullet.Instance1.bulletshot == true)
        {
            StartCoroutine("BulletCouroutine");
        }
    }
    IEnumerator BulletCouroutine()
    {
        yield return new WaitForSeconds(1);
        if (gameObject.name == "Muzzle_Flash")
        {
            print("bullet op Coroutine called");
            Bullet.Instance1.AddBullettoHitPrefabPool(this.gameObject);
        }
    }
}
