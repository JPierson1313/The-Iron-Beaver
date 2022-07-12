using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour
{
    public Transform playerPos;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(playerPos.position, Vector3.up, speed * Time.deltaTime);
    }
}
