using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rbd;

    [SerializeField] private float _forceRange;
    [SerializeField] private GameObject _nextBallPrefab;


    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();

        float force = Random.Range(-_forceRange, _forceRange);
        _rbd.AddForce(transform.position * 3, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if (_nextBallPrefab != null)
        {
            GameObject ball01 = Instantiate(_nextBallPrefab, transform.position, Quaternion.identity) as GameObject;
            GameObject ball02 = Instantiate(_nextBallPrefab, transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            Destroy(gameObject);        // At the smalles ball there is no next ball; Therefore destroy it
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
         if(other.collider.tag == "Player")
        {
            print("Player Hit");
        }
    }
}
