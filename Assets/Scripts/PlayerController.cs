using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    Animator animator;
    GameController gameController;

    float moveForce = 0.1f;
    float jumpForce = 5;
    bool isJump, isJumpWait;
    float jumpWaitTimer;

    int playerHP = 100, maxPlayerHP = 100;
    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        TurnOffTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            if (!isJump && !isJumpWait)
            {
                animator.Play("Jump", 0, 0);

                isJumpWait = true;
                jumpWaitTimer = 0.2f;
            }
        }

        if (isJumpWait)
        {
            jumpWaitTimer -= Time.deltaTime;
            if (0 > jumpWaitTimer)
            {
                GetComponent<Rigidbody>().velocity = transform.up * jumpForce;

                isJumpWait = false;
                isJump = true;
            }
        }

        if (transform.position.y < -5 && transform.position.y > -20)
        {
            Destroy(gameObject);
            hpBar.value = 0;
            gameController.GameOver();
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Run", true);
            transform.Translate(0f, 0f, moveForce);
            mainCamera.transform.position += new Vector3(0f, 0f, moveForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Run", true);
            transform.Translate(0f, 0f, -moveForce);
            mainCamera.transform.position += new Vector3(0f, 0f, -moveForce);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Run", true);
            transform.Translate(-moveForce, 0f, 0f);
            mainCamera.transform.position += new Vector3(-moveForce, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Run", true);
            transform.Translate(moveForce, 0f, 0f);
            mainCamera.transform.position += new Vector3(moveForce, 0f, 0f);
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJump = false;
    }

    public void TurnOffTrigger()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
    }
}
