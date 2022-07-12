using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransitionScript : MonoBehaviour
{
    public string sceneName;
    public GameObject transition;
    public float countdownTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer < 0)
        {
            transition.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(sceneName);
    }
}
