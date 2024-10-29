using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float speed = 10.0f;
    private GameObject focalPoint;
    private Renderer rendererPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rendererPlayer = GetComponent<Renderer>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float magnitude = forward * speed * Time.deltaTime;
        rbPlayer.AddForce(focalPoint.transform.forward * magnitude, ForceMode.Impulse);

        if(forward > 0)
        {
            rendererPlayer.material.color = new Color(1.0f - forward, 1.0f, 1.0f - forward);
        }
        else
        {
            rendererPlayer.material.color = new Color(1.0f + forward, 1.0f, 1.0f + forward);
        }


    }
}
