using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Animator animator;
    private float time;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    public enum Direction { Up, Down, Right, Left };
    public Direction bossDirection;

    float shotHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shotPoint.position = shotPoint.position + new Vector3(0, shotHeight, -3f);
        time = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Throw();
    }

    void Throw()
    {
        if (time >= 1.0f)
        {
            animator.SetBool("Throw", true);
            Invoke(nameof(ShotSnow), 2f);
            shotPoint.position = transform.position + new Vector3(0, shotHeight, -2f);
            Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
            time = 0.0f;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Idle", true);
        }
    }

    void ShotSnow()
    {
        transform.position += new Vector3(0f, 0f, 0f);
    }
}
