using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIShipMovement : MonoBehaviour
{
    [Header("Traveling Area")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    [Header("Distance Systems")]
    public Transform moveSpot;
    public int distance;
    //public int distanceToPlayer;

    //public int moveAwayX = 10;
    //public int moveAwayZ = 10;
    Transform player;

    [Header("Variables")]
    public float speed;
    public float damping = 1;
    Vector3 rotation;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform point = Instantiate(moveSpot, transform.position, transform.rotation);
        moveSpot = point;
        moveSpot.position = new Vector3(Random.Range(minX, maxX), moveSpot.position.y, Random.Range(minZ, maxZ));
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //LookAt();

        if (Vector3.Distance(transform.position, moveSpot.position) < distance)
        {
            moveSpot.position = new Vector3(Random.Range(minX, maxX), moveSpot.position.y, Random.Range(minZ, maxZ));
        }

        //else if (Vector3.Distance(transform.position, player.position) < distanceToPlayer)
        //{
        //moveSpot.position = new Vector3(transform.position.x - moveAwayX, transform.position.y, transform.position.z - moveAwayZ);
        //}

        agent.destination = moveSpot.position;
    }

    void LookAt()
    {

        //sets "rotation" variable as the rotation to look at target  
        //rotation = (moveSpot.position - transform.position);
        //rotation.y = 0.0f;

        // slows rotation based on variable Damping 
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), Time.deltaTime * damping);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
