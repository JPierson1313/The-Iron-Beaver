using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour
{
    public int timer;
    public GameObject waterExplosion;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(waterExplosion, transform.position, transform.rotation);
    }
}
