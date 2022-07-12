using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCannonSystems : MonoBehaviour
{
    Transform target;
    public float angleFire = 5;
    Vector3 targetDir;

    [Header("Cannon Systems")]
    public GameObject cannonball;
    public GameObject cannonExplosion;
    public float minCannonPower;
    public float maxCannonPower;
    public int shootInterval = 5;

    float cooldown;
    float cannonPower;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        cooldown = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < angleFire)
        {
            if (cooldown > 0)
                return;

            cooldown = shootInterval;

            cannonPower = Random.Range(minCannonPower, maxCannonPower);
            GameObject cb = Instantiate(cannonball, transform.position, transform.rotation);
            Instantiate(cannonExplosion, transform.position, transform.rotation);
            cb.GetComponent<Rigidbody>().AddForce(transform.forward * cannonPower);
        }
    }
}
