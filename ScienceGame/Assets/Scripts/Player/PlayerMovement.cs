using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private JumpCol jumpCol;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        
        jumpCol = GetComponentInChildren<JumpCol>();
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        Move();
        Jump();

    }

    private void Jump()
    {

        if (jumpCol.IsGround == true && Input.GetKeyDown(KeyCode.Space))
        {

            playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        }

    }

    private void Move()
    {

        float inputRaw = Input.GetAxisRaw("Horizontal");
        float input = Input.GetAxis("Horizontal");
        bool isMove = inputRaw != 0;
        float slowSpeed = isMove ? 1.0f : 0.5f;

        playerRigidbody.velocity = new Vector2 (input * speed * slowSpeed, playerRigidbody.velocity.y);

    }

}
