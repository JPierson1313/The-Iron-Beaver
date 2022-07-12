using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSystem : MonoBehaviour
{
    Transform target;
    VRDivingSystem vrds;

    [Header("Distance")]
    public float distance;
    public float attackRange;

    [Header("Cannon Systems")]
    public GameObject cannonball;
    public Transform barrelEnd;
    public GameObject cannonExplosion;
    public float minCannonPower;
    public float maxCannonPower;

    public float cooldown;

    public int shootInterval = 5;
    float cannonPower;

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

        cannonPower = Random.Range(minCannonPower, maxCannonPower);
        GameObject cb = Instantiate(cannonball, barrelEnd.position, barrelEnd.rotation);
        Instantiate(cannonExplosion, barrelEnd.position, barrelEnd.rotation);
        cb.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * cannonPower);
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
