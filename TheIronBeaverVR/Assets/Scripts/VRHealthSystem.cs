using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class VRHealthSystem : MonoBehaviour
{
    [Header("Health Systems")]
    public float playerHealth = 250;
    public float maxHealth = 250;

    [Header("Repair Systems")]
    public float repairReset = 5;
    public float repairCountdown;
    public bool isRepairing = false;

    [Header("Health & Repair UI Elements")]
    public Image repairBar;
    public Image healthBar;
    public Text repairText;

    [Header("Game Over Systems")]
    public GameObject gameoverScreen;
    public bool isDead = false;

    [Header("VR Controls")]
    public SteamVR_Action_Boolean TriggerClick;
    public SteamVR_Input_Sources inputSource;

    // Start is called before the first frame update
    void Start()
    {
        repairBar.fillAmount = 0;
        repairCountdown = repairReset;
        playerHealth = maxHealth;
        repairText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth / maxHealth;

        if (playerHealth < maxHealth / 2)
        {
            healthBar.color = Color.red;
        }

        else if (playerHealth < maxHealth)
        {
            healthBar.color = Color.yellow;
        }

        else if (playerHealth >= maxHealth)
        {
            playerHealth = maxHealth;
            healthBar.color = new Color32(0, 31, 149, 255);
        }

        if (playerHealth <= 0)
        {
            isDead = true;
            gameoverScreen.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        if (TriggerClick.GetState(inputSource) && playerHealth < maxHealth && isDead == false)
        {
            isRepairing = true;
            repairText.text = "Repairing!";
            repairBar.fillAmount += 1 / repairReset * Time.deltaTime;
            repairCountdown -= Time.deltaTime;

            if (repairCountdown > 0)
                return;
            else
            {
                repairCountdown = repairReset;
                playerHealth += 25;
                repairBar.fillAmount = 0;
            }
        }

        else
        {
            isRepairing = false;
            repairCountdown = repairReset;
            repairBar.fillAmount = 0;
            repairText.text = "";
        }

    }
}
