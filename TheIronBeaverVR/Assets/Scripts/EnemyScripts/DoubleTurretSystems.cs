using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTurretSystems : MonoBehaviour
{
    Transform target;
    VRDivingSystem vrds;

    [Header("Distance")]
    public float distance;
    public float attackRange;

    [Header("Left Cannon Systems")]
    public Transform leftBarrelEnd;
    float leftCannonPower;

    [Header("Right Cannon Systems")]
    public Transform rightBarrelEnd;
    float rightCannonPower;

    [Header("Cannon Systems")]
    public GameObject cannonball;
    public GameObject cannonExplosion;
    public float minCannonPower;
    public float maxCannonPower;

    public float cooldown;

    public int shootInterval = 8;

    [Header("Turret")]
    public float damping = 1;

    // Start is called before the first frame update
    void Start()
    {
        vrds = GameObject.FindGameObjectWithTag("DiverTag").GetComponent<VRDivingSystem>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        cooldown = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        distance = Vector3.Distance(target.transform.position, transform.position);
        LookAt();

        if (distance < attackRange && vrds.isDiving == false)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (cooldown > 0)
            return;

        cooldown = shootInterval;

        leftCannonPower = Random.Range(minCannonPower, maxCannonPower);
        rightCannonPower = Random.Range(minCannonPower, maxCannonPower);
        GameObject leftCB = Instantiate(cannonball, leftBarrelEnd.position, leftBarrelEnd.rotation);
        GameObject rightCB = Instantiate(cannonball, rightBarrelEnd.position, rightBarrelEnd.rotation);
        Instantiate(cannonExplosion, leftBarrelEnd.position, leftBarrelEnd.rotation);
        Instantiate(cannonExplosion, rightBarrelEnd.position, rightBarrelEnd.rotation);
        leftCB.GetComponent<Rigidbody>().AddForce(leftBarrelEnd.forward * leftCannonPower);
        rightCB.GetComponent<Rigidbody>().AddForce(rightBarrelEnd.forward * rightCannonPower);
    }

    void LookAt()
    {
        Vector3 rotation;
        rotation = (target.transform.position - transform.position);
        rotation.y = 0.0f;

        // slows rotation based on variable Damping 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * damping);
    }
}
