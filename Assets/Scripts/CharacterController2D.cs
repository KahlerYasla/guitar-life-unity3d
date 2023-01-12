using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the horizontal and vertical inputs
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Normalize the inputs
        //inputNormalize(ref moveX, ref moveY);

        // Get the running input
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Calculate the movement speed
        float moveSpeedMod = moveSpeed;
        if (isRunning)
        {
            moveSpeedMod *= 2;
        }

        // Move the player
        rb.velocity = new Vector2(moveX * Time.deltaTime, moveY * Time.deltaTime).normalized * moveSpeedMod;

        // Update the animator
        anim.SetFloat("moveX", moveX);
        anim.SetFloat("moveY", moveY);

        if (Mathf.Abs(moveX) < 0.1f && Mathf.Abs(moveY) < 0.1f)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        else
        {
            if (!isRunning)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isWalking", false);
            }
        }
    }

    /*
        void inputNormalize(ref float moveX, ref float moveY)
        {
            if (moveX == 1)
                moveX = 1;
            else if (moveX == -1)
                moveX = -1;
            else
                moveX = 0;

            if (moveY == 1)
                moveY = 1;
            else if (moveY == -1)
                moveY = -1;
            else
                moveY = 0;
        }
    */

}
