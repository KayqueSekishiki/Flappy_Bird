using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _thisRigidBody;


    [Header("Jump Settings")]
    public float jumpForce = 0.1f;
    public float jumpInterval = 0.5f;
    private float _jumpCooldown = 0;



    void Start()
    {
        _thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _jumpCooldown -= Time.deltaTime;
        bool canJump = _jumpCooldown <= 0;

        if (canJump)
        {
            bool jumpInput = Input.GetKeyDown(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        _jumpCooldown = jumpInterval;

        _thisRigidBody.velocity = Vector3.zero;
        _thisRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
