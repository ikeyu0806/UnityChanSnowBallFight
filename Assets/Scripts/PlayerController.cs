using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveForce = 0.1f;
    float jumpForce = 5;

    Animator animator;

    bool isJump, isJumpWait;
    float jumpWaitTimer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space"))
        {
            if(!isJump && !isJumpWait)
            {
                animator.Play("Jump", 0, 0);

                isJumpWait = true;
                jumpWaitTimer = 0.2f;
            }
        }

        if(isJumpWait)
        {
            jumpWaitTimer -= Time.deltaTime;
            if(0 > jumpWaitTimer)
            {
                GetComponent<Rigidbody>().velocity = transform.up * jumpForce;

                isJumpWait = false;
                isJump = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, moveForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -moveForce);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveForce, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveForce, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }
}
