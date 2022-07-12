using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class VRGoToNextLevel : MonoBehaviour
{
    public string sceneName;
    public GameObject transition;
    public SteamVR_Action_Boolean TriggerClick;
    public SteamVR_Input_Sources inputSource;

    private void Start() { } //Monobehaviours without a Start function cannot be disabled in Editor, just FYI

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        transition.SetActive(true);
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(sceneName);
    }
}
