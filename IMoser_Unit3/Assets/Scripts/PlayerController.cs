using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rbPlayer;
    public float gravityModifier;
    public float jumpForce;
    private bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if(spaceDown && onGround)
        {
            rbPlayer.AddForce(Vector3.up * 10, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        onGround = true;
    }
}
