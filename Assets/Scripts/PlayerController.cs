using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera;
    Animator animator;
    GameController gameController;

    public GameObject bulletPrefab;

    float moveForce = 0.1f;
    float jumpForce = 5;
    bool isJump, isJumpWait;
    float jumpWaitTimer;

    float shotHeight = 0.5f;
    float shotRemoteRange = 0.5f;

    int playerHP = 100;
    public Slider hpBar;

    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        shotPoint.position = transform.position + new Vector3(0f, 0f, 10f);
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
                animator.SetBool("Idle", true);
            }
        }

        if (transform.position.y < -5 && transform.position.y > -20)
        {
            GameOver();
        }

        Shot();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("Run", true);
            transform.position += new Vector3(0f, 0f, moveForce);
            mainCamera.transform.position += new Vector3(0f, 0f, moveForce);
            shotPoint.position = transform.position + new Vector3(0f, shotHeight, shotRemoteRange);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("Run", true);
            transform.position += new Vector3(moveForce, 0f, 0f);
            mainCamera.transform.position += new Vector3(moveForce, 0f, 0f);
            shotPoint.position = transform.position + new Vector3(shotRemoteRange, shotHeight, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Run", true);
            transform.position += new Vector3(0f, 0f, -moveForce);
            mainCamera.transform.position += new Vector3(0f, 0f, -moveForce);
            shotPoint.position = transform.position + new Vector3(0f, shotHeight, -shotRemoteRange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("Run", true);
            transform.position += new Vector3(-moveForce, 0f, 0f);
            mainCamera.transform.position += new Vector3(-moveForce, 0f, 0f);
            shotPoint.position = transform.position + new Vector3(-shotRemoteRange, shotHeight, 0f);
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

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
        }
    }

    public void TakeHit(float damage)
    {
        playerHP = (int)Mathf.Clamp(playerHP - damage, 0, playerHP);

        HPUpdate();

        if (playerHP <= 0)
        {
            GameOver();
        }
    }

    public void HPUpdate()
    {
        hpBar.value = playerHP;
    }

    public void GameOver()
    {
        Destroy(gameObject);
        hpBar.value = 0;
        gameController.GameOver();
    }
}
