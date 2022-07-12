using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRDivingSystem : MonoBehaviour
{
    [Header("Diving & Rising Systems")]
    public Transform divingPoint;
    public Transform risingPoint;
    public float verticalSpeed = 3;
    public bool isDiving = false;

    [Header("VR Controls")]
    public SteamVR_Action_Boolean TriggerClick;
    public SteamVR_Input_Sources inputSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void FixedUpdate()
    {
        if (TriggerClick.GetState(inputSource))
        {
            isDiving = true;
            transform.position = Vector3.MoveTowards(transform.position, divingPoint.position, verticalSpeed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, risingPoint.position, verticalSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Rise"))
        {
            isDiving = false;
        }
    }
}
