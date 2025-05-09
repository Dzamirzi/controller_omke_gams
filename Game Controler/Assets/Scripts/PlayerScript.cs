using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpPower = 10.0f;
    public float moveSpeed = 5.0f;
    public float dashForce = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1.0f;

    Rigidbody2D myRigidbody;
    public bool isGrounded = false;
    float posX = -9.5f;
    bool isGameOver = false;
    bool isDashing = false;
    bool canDash = true;
    float dashTimeLeft;

    ChallengerController myChallengeController;
    GameController myGameController;

    void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        myChallengeController = FindObjectOfType<ChallengerController>();
        myGameController = FindObjectOfType<GameController>();
    }

    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            if (isDashing)
            {
                dashTimeLeft -= Time.fixedDeltaTime;
                if (dashTimeLeft <= 0)
                {
                    isDashing = false;
                }
            }
            else
            {
                float move = Input.GetAxis("Horizontal");
                myRigidbody.velocity = new Vector2(move * moveSpeed, myRigidbody.velocity.y);

                if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && move != 0 && canDash)
                {
                    StartCoroutine(Dash(move));
                }
            }
        }

        // Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidbody.AddForce(Vector2.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }

        // Game over if player moves too far left
        if (transform.position.x < posX)
        {
            GameOver();
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        canDash = false;
        dashTimeLeft = dashDuration;
        myRigidbody.velocity = new Vector2(Mathf.Sign(direction) * dashForce, myRigidbody.velocity.y);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void GameOver()
    {
        Debug.Log("End Game");
        isGameOver = true;
        myChallengeController.GameOver();
        myRigidbody.velocity = Vector2.zero;
    }

    void AddScore()
    {
        myGameController.IncrementScore();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.collider.tag == "Enemy")
        {
            GameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gold")
        {
            myGameController.IncrementScore();
            Destroy(other.gameObject);
        }
    }
}
