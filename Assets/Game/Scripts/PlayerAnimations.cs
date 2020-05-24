using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _anim;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Horizontal") < 0)
        { //left

            _anim.SetBool("TurnRight", false);
            _anim.SetBool("TurnLeft", true);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {//right
            _anim.SetBool("TurnRight", true);
            _anim.SetBool("TurnLeft", false);

        }
        else
        {
            //idle
            _anim.SetBool("TurnRight", false);
            _anim.SetBool("TurnLeft", false);
        }
        
    }
}
