using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using System;
using System.Runtime.InteropServices;

public class moveRestore : MonoBehaviour
{

    [DllImport("RestoreDll")]
    private static extern int NewHP(int hp, int add);

    private Rigidbody rb;
    public float speed;
    private float dirX;
    private bool grounded;
    public Vector3 jump;

    public int HP = 1;
    public int HPAdd = 2;

    void Start()
    {
        speed = 3f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 5f, 0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("Win");
        }

        if (collision.gameObject.tag == "HP")
        {
            HP = NewHP(HP, HPAdd);
            Destroy(collision.gameObject);
        }

    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump, ForceMode.Impulse);
        }

        if (gameObject.transform.position.x >= 0.113f)
        {
            transform.position = new Vector3(0.113f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x <= -21.46f)
        {
            transform.position = new Vector3(-21.46f, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (HP == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, rb.velocity.z);
    }
}
