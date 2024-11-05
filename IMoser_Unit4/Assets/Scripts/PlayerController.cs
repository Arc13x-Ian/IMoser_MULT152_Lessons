using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float speed = 10.0f;
    public float powerUpSpeed = 1.0f;
    public GameObject powerUpIndicator;

    private GameObject focalPoint;
    private Renderer rendererPlayer;
    
    private bool hasPowerUp = false;
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

        powerUpIndicator.transform.position = transform.position;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountdown());
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(hasPowerUp && collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Player bonked " + collision.gameObject + " while powered up");

            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayVector = collision.gameObject.transform.position - transform.position;

            rbEnemy.AddForce(awayVector * powerUpSpeed, ForceMode.Impulse);

        }

    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);

        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
