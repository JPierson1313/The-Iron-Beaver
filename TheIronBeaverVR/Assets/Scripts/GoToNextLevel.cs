using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public string sceneName;
    public GameObject transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
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
