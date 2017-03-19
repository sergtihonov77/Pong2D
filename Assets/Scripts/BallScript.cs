using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private bool _ballIsActive;

    private Vector3 _ballPosition;

    public GameObject playerObject;

    private Rigidbody2D _rg;

    public AudioClip hitSound;

    private float _speed;

    void Start()
    {

        _ballIsActive = false;

        //start position
        _ballPosition = transform.position;

        _rg = GetComponent<Rigidbody2D>();

        _speed = 7;
    }

    void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check state
            if (!_ballIsActive)
            {
                //Add start speed to the ball
                _rg.velocity = Vector2.up * _speed;

                //Set active state
                _ballIsActive = true;

                if (_ballIsActive && playerObject != null)
                {
                    //Set the position of the ball above the platform
                    _ballPosition.x = playerObject.transform.position.x;
                    _ballPosition.y = playerObject.transform.position.y + (float)0.3;
                    transform.position = _ballPosition;
                }

            }

            //If ball fall uder ground
            if (_ballIsActive && transform.position.y < -6)
            {
                _ballIsActive = false;
                _ballPosition.x = playerObject.transform.position.x;
                _ballPosition.y = playerObject.transform.position.y + (float)0.3;
                transform.position = _ballPosition;
                playerObject.SendMessage("TakeLife");
            }
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Hit Sound
        if (_ballIsActive)
        {
            GetComponent<AudioSource>().PlayOneShot(hitSound);
        }

        if (collision.gameObject.name == "Player")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
           _rg.velocity = dir * _speed;
        }
    }

    //Checking what part of the platform the ball hit
    float hitFactor(Vector2 ballPos, Vector2 playerPos,
                float playerWidth)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.x - playerPos.x) / playerWidth;
    }
}
