using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructedTools : MonoBehaviour
{
    [SerializeField]
    private GameObject crate;

    public void OnCrateDestroy()
    {
        Instantiate(crate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
