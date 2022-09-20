using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float moveDetectErr;
    [SerializeField] private AudioSource walkSound;

    private JumpCol jumpCol;
    private Rigidbody2D playerRigidbody;
    private Animator anim;
    private int scaleFactor = 1;
    private ShootMagic myShoot;
    private bool playingSound = false;

    private void Awake()
    {
        
        jumpCol = GetComponentInChildren<JumpCol>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myShoot = GetComponent<ShootMagic>();
    }

    private void Update()
    {
		if (!myShoot.shooting)
		{
            Move();
            Jump();
		}
        SetAnim();
    }

    private void SetAnim()
	{
        anim.SetBool("IsGround", jumpCol.IsGround);
        anim.SetFloat("velY", playerRigidbody.velocity.y);
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
        
        if(Approximate(inputRaw, 1f, moveDetectErr))
		{
            scaleFactor = 1;
		}
        else if (Approximate(inputRaw, -1f, moveDetectErr))
        {
            scaleFactor = -1;
        }

        playerRigidbody.velocity = new Vector2 (input * speed * slowSpeed, playerRigidbody.velocity.y);
        anim.SetBool("IsMoving", isMove);
        transform.localScale = new Vector3( scaleFactor, transform.localScale.y, transform.localScale.z);

        if (jumpCol.IsGround && isMove && !playingSound)
        {
            Debug.Log("!");
            playingSound = true;
            walkSound.Play();
        }
		else if((!isMove || !jumpCol.IsGround) && playingSound)
		{
            playingSound = false;
            Debug.Log("...");
            walkSound.Stop();
		}
    }

    bool Approximate(float a, float b, float err)
	{
        return Mathf.Abs(a - b) < err;
	}
}
