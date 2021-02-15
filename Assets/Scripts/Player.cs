using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _playerSpeed = 10.0f;
    [SerializeField]
    private float _jumpHeight = 25.0f;
    [SerializeField]
    private float _dbJumpHeight = 23.0f;
    [SerializeField]
    private float _gravityValue = -1.81f;
    private float _yVelocity = 0;

    private bool _canDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, 0);
        Vector2 velocity = direction * _playerSpeed;

        if(_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                    _yVelocity += _dbJumpHeight;
                    _canDoubleJump = false;
                }

            }
            _yVelocity += _gravityValue;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

        if(transform.position.y < -7.5f)
        {
            transform.position = new Vector3(-11.12f, 3.84f, -4f);
        }
    }
}
