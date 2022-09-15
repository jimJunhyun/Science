using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCol : MonoBehaviour
{

    private bool isGround;
    public bool IsGround => isGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        isGround = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        isGround = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        isGround = false;

    }

}
