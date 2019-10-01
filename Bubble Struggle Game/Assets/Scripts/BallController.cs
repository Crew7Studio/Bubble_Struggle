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

        float force = Random.Range(1, _forceRange);
        _rbd.AddForce(transform.position * force, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if (_nextBallPrefab != null)
        {
            GameObject ball01 = Instantiate(_nextBallPrefab, _rbd.position + Vector2.right / 4f , Quaternion.identity) as GameObject;
            GameObject ball02 = Instantiate(_nextBallPrefab, _rbd.position + Vector2.left / 4f, Quaternion.identity) as GameObject;
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
