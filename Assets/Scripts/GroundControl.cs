using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{

    InputManager inputManager;

    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        inputManager = FindObjectOfType<InputManager>();
    }

    public void Rise() {
        myAnimator.SetTrigger("rise");
    }

    public void EndRise() {
        FindObjectOfType<LevelController>().PlayerToGround();
    }
}
