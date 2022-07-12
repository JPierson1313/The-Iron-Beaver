using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeriscopeSystems : MonoBehaviour
{
    int rotationSpeed = 100;
    float ShootInterval = 3f;

    [Header("Diving & Rising Systems")]
    public Transform divingPoint;
    public Transform risingPoint;
    public float verticalSpeed = 3;
    public bool isDiving = false;

    [Header("Torpedo Tubes")]
    public Transform leftTorpedoTube;
    public Transform rightTorpedoTube;
    public GameObject torpedo;

    float leftCooldown = 0;
    float rightCooldown = 0;

    [Header("Torpedo UI Elements")]
    public Image leftTorpedoBar;
    public Image rightTorpedoBar;
    public Text leftTorpText;
    public Text rightTorpText;

    [Header("Scripts")]
    public PlayerHealthSystem phs;

    void FixedUpdate()
    {
        Vector3 desiredDirection = new Vector3();
        desiredDirection.y = Input.GetAxis("Horizontal");
        transform.Rotate(desiredDirection * rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        leftCooldown -= Time.deltaTime;
        rightCooldown -= Time.deltaTime;

        leftTorpedoBar.fillAmount += 1/ShootInterval * Time.deltaTime;
        rightTorpedoBar.fillAmount += 1/ShootInterval * Time.deltaTime;

        if(leftTorpedoBar.fillAmount == 1)
        {
            leftTorpText.text = "Ready!";
        }

        if (rightTorpedoBar.fillAmount == 1)
        {
            rightTorpText.text = "Ready!";
        }

        if (Input.GetKeyDown(KeyCode.Q) && phs.isRepairing != true  && isDiving != true)
        {
            LeftTube();
        }

        if(Input.GetKeyDown(KeyCode.E) && phs.isRepairing != true  && isDiving != true)
        {
            RightTube();
        }

        if (Input.GetKey(KeyCode.S))
        {
            isDiving = true;
            transform.position = Vector3.MoveTowards(transform.position, divingPoint.position, verticalSpeed * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, risingPoint.position, verticalSpeed * Time.deltaTime);
        }
    }

    void LeftTube()
    {
        if (leftCooldown > -0.1f)
            return;

        leftTorpedoBar.fillAmount = 0;
        leftTorpText.text = "Reloading!";

        leftCooldown = ShootInterval;
        GameObject Torp = Instantiate(torpedo, leftTorpedoTube.position, leftTorpedoTube.rotation);
        Torp.GetComponent<Rigidbody>().AddForce(leftTorpedoTube.forward * 800);
    }

    void RightTube()
    {
        if (rightCooldown > -0.1f)
            return;

        rightTorpedoBar.fillAmount = 0;
        rightTorpText.text = "Reloading!";

        rightCooldown = ShootInterval;
        GameObject Torp = Instantiate(torpedo, rightTorpedoTube.position, rightTorpedoTube.rotation);
        Torp.GetComponent<Rigidbody>().AddForce(rightTorpedoTube.forward * 800);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Rise"))
        {
            isDiving = false;
        }
    }
}
