using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class SceneTopBar : MonoBehaviour
{
    private GameObject VRButton;
    private GameObject ARButton;

    private GameObject onFlash;
    private GameObject offFlash;

    //Hidden Text for switching between AR and VR Mode
    public Text VRbuttonText;

    private Animator animator;
    private bool isTopBarMenuOn = false;

    //Torch Status
    private bool isTorchOn = false;

    //Mode for viewing status
    private MixedRealityController.Mode VRMode = MixedRealityController.Mode.VIEWER_AR;
    private MixedRealityController.Mode ARMode = MixedRealityController.Mode.HANDHELD_AR;

    void Start()
    {

        

        animator = GetComponent<Animator>();
        VRbuttonText.text = "AR";

        ARButton = GameObject.Find("AR Mode");
        VRButton = GameObject.Find("VR Mode");

        ARButton.SetActive(false);

        onFlash = GameObject.Find("Flash active");
        offFlash = GameObject.Find("Flash deactive");

        onFlash.SetActive(false);


    }

    public void playAnimationForTopBarMenu() {
        if (isTopBarMenuOn) {
            Debug.Log("Menu Activity - Menu closed.");
            animator.Play("menu_hareket_yukari");
            isTopBarMenuOn = false;

        } else {
            Debug.Log("Menu Activity - Menu opened.");
            animator.Play("menu_hareket_asagi");
            isTopBarMenuOn = true;
        }
    }



    //Switching between AR and VR
    public void switchToVR() {
        if (VRbuttonText.text.Equals("VR")) {
            Debug.Log("Menu Activity - Viewing Mode is changing to AR");
            modeSwap(ARMode);
            VRbuttonText.text = "AR";

            ARButton.SetActive(false);
            VRButton.SetActive(true);


            playAnimationForTopBarMenu();

        } else {
            Debug.Log("Menu Activity - Viewing Mode is changing to VR");
            modeSwap(VRMode);
            VRbuttonText.text = "VR";

            ARButton.SetActive(true);
            VRButton.SetActive(false);

            playAnimationForTopBarMenu();
        }

    }

    //AR/VR Swapping func. 
    void modeSwap(MixedRealityController.Mode mode) {

        if (mode == VRMode) {

            IEnumerable<IViewerParameters> viewerParameters = Device.Instance.GetViewerList().GetAllViewers();

            foreach (IViewerParameters vp in viewerParameters)
                if (vp.GetName().Equals("Cardboard v1"))
                    MixedRealityController.Instance.SetViewerParameters(vp);
            MixedRealityController.Instance.SetMode(VRMode);


        } else {
            MixedRealityController.Instance.SetMode(ARMode);
        }

    }


    //Switching Torch Mode
    public void switchModeFlashLight() {
        if (isTorchOn) {
            Debug.Log("Torch status changed to: CLOSE");

            CameraDevice.Instance.SetFlashTorchMode(false);
            isTorchOn = false;

            onFlash.SetActive(false);
            offFlash.SetActive(true);
            playAnimationForTopBarMenu();
        } else {
            Debug.Log("Menu Activity - Torch status changed to: OPEN");
            CameraDevice.Instance.SetFlashTorchMode(true);
            isTorchOn = true;

            onFlash.SetActive(true);
            offFlash.SetActive(false);
            playAnimationForTopBarMenu();
        }

    }

    //Exiting From Game
    public void exitFromGame() {
        Debug.Log("Menu Activity - Quiting from game");
        Application.Quit();
    }

    public static T FindComponentInChildWithTag<T>(GameObject parent, string tag) where T : Component {
        Transform t = parent.transform;
        foreach (Transform tr in t) {
            if (tr.tag == tag) {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }
}
