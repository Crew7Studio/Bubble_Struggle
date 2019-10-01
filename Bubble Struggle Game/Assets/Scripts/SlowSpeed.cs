using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeed : MonoBehaviour
{

    [SerializeField] private float _delayTime = 5f;
    [SerializeField] private float _gravityScale = .5f;

    private float _delayCounter;

    void Start()
    {
        StartCoroutine(Slow());
    }

    private IEnumerator Slow() {

        BallController[] balls = GameObject.FindObjectsOfType<BallController>();
        
        foreach(var ball in balls)
        {
            print(ball.name);
       
            ball.GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
            ball.GetComponent<Rigidbody2D>().mass = 5;

            yield return new WaitForSeconds(_delayTime);
            ball.GetComponent<Rigidbody2D>().gravityScale = 1f;
            ball.GetComponent<Rigidbody2D>().mass = 1f;


        }
    }
}

    
