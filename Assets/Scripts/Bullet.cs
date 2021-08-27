using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject muzzleFlashPrefab;
    [SerializeField]
    private GameObject CurrentmuzzleFlashPrefab;
    public bool bulletshot = false;
    private static Bullet instance;
    Stack<GameObject> BulletPool = new Stack<GameObject>();
    public GameObject firePoint;
    public float timer = 1.0f;
    public float fireRate = 1.0f;
   
    public static Bullet Instance1
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Bullet>();
            }
            return instance;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletshot = true;
            SpawnBulletPrefab();
        }
    }
    void BulletPrefabs()//bullet
    {

        BulletPool.Push(Instantiate(muzzleFlashPrefab));
        BulletPool.Peek().SetActive(false);
        BulletPool.Peek().name = "Muzzle_Flash";
    }
    public void AddBullettoHitPrefabPool(GameObject bullettemp)//bullet
    {
        //print("added to the pool");
        BulletPool.Push(bullettemp);
        BulletPool.Peek().SetActive(false);
        //shot = false;
        bulletshot = false;
    }
    public void SpawnBulletPrefab()//bullet
    {
        print("Spawn bullet called");
        if (BulletPool.Count >= 0)
        {
            //print("count is zero");
            BulletPrefabs();
        }
        GameObject tempbulletPrefab = BulletPool.Pop();
        tempbulletPrefab.SetActive(true);
        tempbulletPrefab.transform.position = firePoint.transform.position;
        CurrentmuzzleFlashPrefab = tempbulletPrefab;
    }



}
