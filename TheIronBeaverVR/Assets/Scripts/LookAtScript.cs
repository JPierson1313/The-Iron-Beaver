using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y, 0);
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
