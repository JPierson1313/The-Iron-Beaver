using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSystem : MonoBehaviour
{
    public float timer;
    public float damage;
    public VRHealthSystem phs;
    //public PlayerHealthSystem phs;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
        phs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VRHealthSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            phs.playerHealth -= damage;
        }
    }
}
