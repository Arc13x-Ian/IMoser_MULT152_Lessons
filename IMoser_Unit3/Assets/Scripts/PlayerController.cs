using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround;
    public bool gameOver = false;

    private Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        animPlayer = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if(spaceDown && onGround && !gameOver)
        {
            rbPlayer.AddForce(Vector3.up * 10, ForceMode.Impulse);
            onGround = false;
            animPlayer.SetTrigger("Jump_trig");
        }

        //also setting a falling animation cuz I can
        if(!onGround && rbPlayer.velocity.y < 0)
        {
            animPlayer.SetBool("Grounded", false);
        }
        else
        {
            animPlayer.SetBool("Grounded", true);
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Oh no! You Are Loser!");
            gameOver = true;

            //this isn't part of the project I just want random death animations
            int randomDeath = Random.Range(1, 2);
            animPlayer.SetInteger("DeathType_int", randomDeath);
            animPlayer.SetBool("Death_b", true);
        }

    }
}
