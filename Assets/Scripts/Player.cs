using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _playerSpeed = 5.0f;
    private float _jumpHeight = 2f;
    private float _gravityVal = -9.81f;
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, 0, 0);
        Vector2 velocity = direction * _playerSpeed;        
        _controller.Move(direction * _playerSpeed * Time.deltaTime);
    }
}
