using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class VRTorpedoSystem : MonoBehaviour
{
    [Header("Torpedo Systems")]
    public Transform torpedoTube;
    public GameObject torpedo;
    public float shootInterval = 3f;
    float cooldown = 0;

    [Header("Torpedo UI Elements")]
    public Image torpedoBar;
    public Text torpText;

    [Header("Scripts")]
    public VRHealthSystem vrhs;
    public VRDivingSystem vrds;

    [Header("VR Controls")]
    public SteamVR_Action_Boolean TriggerClick;
    public SteamVR_Input_Sources inputSource;

    private void Update()
    {
        cooldown -= Time.deltaTime;
        torpedoBar.fillAmount += 1 / shootInterval * Time.deltaTime;
        if (torpedoBar.fillAmount == 1)
        {
            torpText.text = "Ready!";
        }
    }

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
        if(vrhs.isRepairing == false && vrds.isDiving == false && vrhs.isDead == false)
        {
            if (cooldown > -0.1f)
                return;

            torpedoBar.fillAmount = 0;
            torpText.text = "Reloading!";

            cooldown = shootInterval;
            GameObject Torp = Instantiate(torpedo, torpedoTube.position, torpedoTube.rotation);
            Torp.GetComponent<Rigidbody>().AddForce(torpedoTube.forward * 1200);

        }
    }
}
