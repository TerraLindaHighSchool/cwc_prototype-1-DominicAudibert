using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float turnSpeed = 65.0f;
    private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    private GameManager gameManager;

    public AudioSource carEngineSound;
    //float initialCarEngineSoundPitch;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        //Move the Vehicle Forward
        horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed *forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
    void OnTriggerEnter(Collider other)
    {
        //Makes the car engine sound
        if (other.gameObject.tag == "GameOverTemp")
        {
            carEngineSound.Stop();
            gameManager.GameOver();
        }

    }
}
