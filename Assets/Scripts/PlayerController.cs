using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        bool IsGameActive = GameManager.Instance.IsGameActive();
        bool canJump = _jumpCooldown <= 0 && IsGameActive;

        if (canJump)
        {
            bool jumpInput = Input.GetKeyDown(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        _thisRigidBody.useGravity = IsGameActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor)
        {
            GameManager.Instance.score++;
            Debug.Log(GameManager.Instance.score);
        }
        else
        {
            GameManager.Instance.EndGame();

        }
    }

    private void Jump()
    {
        _jumpCooldown = jumpInterval;

        _thisRigidBody.velocity = Vector3.zero;
        _thisRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
