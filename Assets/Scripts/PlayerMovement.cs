using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;
    [SerializeField]
    private float playerSpeed;
    private float gravity = 9.81f;
    [SerializeField]
    private GameObject muzzleFlashPrefab;
    [SerializeField]
    private GameObject hitMarketPrefab;
    [SerializeField]
    private GameObject currentPrefab;
    private static PlayerMovement instance;
    public bool shot = false;
    AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;

    Stack<GameObject> PrefabPool = new Stack<GameObject>();

    public static PlayerMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerMovement>();
            }
            return instance;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetMouseButton(0))
        {
            audioSource.clip = clip1;
            audioSource.Play();
            
            muzzleFlashPrefab.SetActive(true);
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                audioSource.clip = clip2;
                audioSource.Play();
                shot = true;
                Debug.Log("Raycast got hit"+hit.transform.name);
                //GameObject temp= (GameObject) Instantiate(hitMarketPrefab, hit.point, Quaternion.LookRotation(hit.normal)) ;
                //Destroy(temp, 1.0f);
                SpawnPrefab();
               
              
            }
        
        }
        else
        {
            muzzleFlashPrefab.SetActive(false);
            //shot = false;
        }
    }
   


    void CreatePrefabs()
    {
        print("create prefabs called");
        PrefabPool.Push(Instantiate(hitMarketPrefab));
        PrefabPool.Peek().SetActive(false);
        PrefabPool.Peek().name = "Hit_Marker";
    }
    public void AddtoHitPrefabPool(GameObject temp)
    {
        print("added to the pool");
        PrefabPool.Push(temp);
        PrefabPool.Peek().SetActive(false);
        shot = false;
    }

    public void SpawnPrefab()
    {
        if (PrefabPool.Count == 0)
        {
            print("count is zero");
            CreatePrefabs();
        }
        GameObject tempPrefab = PrefabPool.Pop();
        tempPrefab.SetActive(true);
        tempPrefab.transform.position = currentPrefab.transform.position;
        currentPrefab = tempPrefab;
    }


    private void Movement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * playerSpeed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        character.Move(velocity * Time.deltaTime);
    }
   
}
