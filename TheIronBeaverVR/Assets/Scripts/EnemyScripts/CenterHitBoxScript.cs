using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterHitBoxScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Torp"))
        {
            transform.parent.GetComponent<AIShipHealthSystem>().CenterCollisionDetected(this);
        }
    }
}
