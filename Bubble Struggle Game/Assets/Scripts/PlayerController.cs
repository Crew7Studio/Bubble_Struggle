using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _rbd;
    private bool _isGrounded;

    public static bool canFire;
    public static bool rapidFire;
    public static int score;
    public static int _lifeCount = 5;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject _chainPrefab;


    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
        _isGrounded = false;
        canFire = true;
        rapidFire = false;
        score = 0;
    }

    void FixedUpdate()
    {
        Movement();

        if (Input.GetButtonDown("Fire1") && _isGrounded && canFire)
        {
            Fire();
            if (rapidFire)
            {
                canFire = true;
            }
            else
            {
                canFire = false;
            }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Ball")
        {
            Damage();   


        }else if(other.collider.tag == "RapidFire")
        {
            other.collider.GetComponent<RapidFire>().StartRapidFire();
            other.collider.GetComponentInChildren<SpriteRenderer>().enabled = false;
            other.collider.enabled = false;
        }else if(other.collider.tag == "GiveLife")
        {
            _lifeCount++;
            Destroy(other.gameObject);
        }
       
    }

    public void Damage()
    {
        if (_lifeCount < 1)
            return;

        _lifeCount--;

        if (_lifeCount < 1) {
             GameManager.Instance.GameOver();
        }
       
    }
}
