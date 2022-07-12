using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIShipHealthSystem : MonoBehaviour
{
    [Header("Health & Damage")]
    public float health = 5;
    public float maxHealth = 5;
    public int frontDamage = 1;
    public int centerDamage = 2;
    public int backDamage = 1;

    [Header("GameObjects & Scripts")]
    public Image healthBar;
    public EnemiesLeftScript els;
    public GameObject destroyedShip;

    [Header("Ship Type Booleans")]
    public bool isMerchant;
    public bool isSloop;
    public bool isDestroyer;
    public bool isTrister;
    public bool isBattleship;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        els = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemiesLeftScript>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;

        if(health < maxHealth)
        {
            healthBar.color = Color.yellow;
        }

        if(health < maxHealth/2)
        {
            healthBar.color = Color.red;
        }

        if(health <= 0)
        {
            Death();
        }
    }

    public void FrontCollisionDetected(FrontHitBoxScript FHBScript)
    {
        health -= frontDamage;
    }

    public void CenterCollisionDetected(CenterHitBoxScript CHBScript)
    {
        health -= centerDamage;
    }

    public void BackCollisionDetected(BackHitBoxScript BHBScript)
    {
        health -= backDamage;
    }

    void Death()
    {
        Destroy(gameObject);
        Instantiate(destroyedShip, transform.position, transform.rotation);
        if (isMerchant)
        {
            els.numOfMerchant -= 1;
            els.merchantText.text = "x " + els.numOfMerchant;
        }

        else if (isSloop)
        {
            els.numOfSloop -= 1;
            els.sloopText.text = "x " + els.numOfSloop;
        }

        else if (isDestroyer)
        {
            els.numOfDestroyer -= 1;
            els.destroyerText.text = "x " + els.numOfDestroyer;
        }

        else if (isTrister)
        {
            els.numOfTrister -= 1;
            els.tristerText.text = "x " + els.numOfTrister;
        }

        else if (isBattleship)
        {
            els.numOfBattleship -= 1;
            els.battleshipText.text = "x " + els.numOfBattleship;
        }

    }
}
