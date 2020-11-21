using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator anim;
    public bool isActive= false;
    public GameObject relationWith;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAnim(string animName)
    {
        PlayAnimation playAnimation = relationWith.GetComponent<PlayAnimation>();
        if (null != anim && isActive != true)
        {
            isActive = true;
            playAnimation.isActive = false;
            Debug.Log("Playing Animation: " + animName);

            anim.Play(animName);
        }
        else
        {
            Debug.Log("Playing Animation: " + animName + "-Reverse");
            isActive = false;
            playAnimation.isActive = false;
            anim.Play(animName + "-Reverse");
        }
    }

}
