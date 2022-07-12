using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("Health Systems")]
    public float playerHealth = 250;
    public float maxHealth = 250;

    [Header("GameOver Screen")]
    public GameObject gameOverScreen;

    [Header("Repair Systems")]
    public float repairReset = 5;
    public float repairCountdown;
    public bool isRepairing = false;

    [Header("UI Elements")]
    public Image healthBar;
    public Image repairBar;
    public Text repairText;

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

        if (playerHealth >= maxHealth)
        {
            healthBar.color = new Color32(0, 31, 149, 255);
            playerHealth = maxHealth;
        }

        else if (playerHealth < maxHealth / 2)
        {
            healthBar.color = Color.red;
        }

        else if (playerHealth < maxHealth)
        {
            healthBar.color = Color.yellow;
        }

        if (playerHealth <= 0)
        {
            gameOverScreen.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && playerHealth < maxHealth)
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

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isRepairing = false;
            repairCountdown = repairReset;
            repairBar.fillAmount = 0;
            repairText.text = "";
        }
    }
}
