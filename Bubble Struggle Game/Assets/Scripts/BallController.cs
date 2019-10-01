using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rbd;

    [SerializeField] private Vector2 _startForce;
    [SerializeField] private GameObject _nextBallPrefab;
    [SerializeField] private Vector2 _newForce;


    void Start()
    {
        _rbd = GetComponent<Rigidbody2D>();
        _rbd.AddForce(_startForce, ForceMode2D.Impulse);
    }

    public void Split()
    {
        if (_nextBallPrefab != null)
        {
            GameObject ball01 = Instantiate(_nextBallPrefab, _rbd.position + Vector2.right / 4f , Quaternion.identity) as GameObject;
            GameObject ball02 = Instantiate(_nextBallPrefab, _rbd.position + Vector2.left / 4f, Quaternion.identity) as GameObject;

            ball01.GetComponent<BallController>()._startForce = new Vector2(_newForce.x, _newForce.y);
            ball02.GetComponent<BallController>()._startForce = new Vector2(-_newForce.x, _newForce.y);

        }
        else
        {
            Destroy(gameObject);        // At the smalles ball there is no next ball; Therefore destroy it
        }
    }
}
