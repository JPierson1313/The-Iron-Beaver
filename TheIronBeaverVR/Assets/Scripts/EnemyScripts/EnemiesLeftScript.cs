using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesLeftScript : MonoBehaviour
{
    [Header("Win Screen")]
    public GameObject winScreen;

    [Header("Numbers of Each Enemy Ship")]
    public int totalEnemyNum;
    public int numOfMerchant;
    public int numOfSloop;
    public int numOfDestroyer;
    public int numOfTrister;
    public int numOfBattleship;

    [Header("Enemy Ship Text")]
    public Text merchantText;
    public Text sloopText;
    public Text destroyerText;
    public Text tristerText;
    public Text battleshipText;

    // Update is called once per frame
    void FixedUpdate()
    {
        totalEnemyNum = numOfMerchant + numOfSloop + numOfDestroyer + numOfTrister + numOfBattleship;
    }

    private void Update()
    {
        if (totalEnemyNum == 0)
        {
            winScreen.SetActive(true);
        }
    }
}
