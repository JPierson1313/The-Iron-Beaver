using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollowPoint : MonoBehaviour
{
    public List<Transform> listOfPoints;
    int index;

    [Header("Distance Systems")]
    Transform moveSpot;
    public int distance;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, listOfPoints.Count);
        moveSpot = listOfPoints[index];
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, moveSpot.position) < distance)
        {
            index = Random.Range(0, listOfPoints.Count);
            moveSpot = listOfPoints[index];
        }
        agent.destination = moveSpot.position;
    }
}
