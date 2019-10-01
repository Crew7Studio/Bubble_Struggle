using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rbd;
    private bool _isGrounded;
    public static bool _canFire;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _chainPrefab;

    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
        _isGrounded = false;
        _canFire = true;
    }

    void FixedUpdate()
    {
        Movement();

        if (Input.GetButtonDown("Fire1") && _isGrounded && _canFire)
        {
            Fire();
        }

        
    }


    // Movement and Jumping
    private void Movement()
    {
        _isGrounded = Grounded();

        float xMov = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
            _rbd.velocity = new Vector2(_rbd.velocity.x, _jumpForce);
        }

        // Move the player
        _rbd.velocity = new Vector2(xMov * _speed, _rbd.velocity.y);
    }


    // For checking if grounded
    private bool Grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .1f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * .1f, Color.green);

        if(hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // For fireing the chain / bulled
    private void Fire()
    {
        
        GameObject bullet = Instantiate(_chainPrefab, transform.position, Quaternion.identity) as GameObject;
    }
}
