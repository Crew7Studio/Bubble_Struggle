﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{

    [SerializeField] private float _chainSpeed = 5f;

    void Start()
    {
        PlayerController.canFire = false;
    }

    void Update()
    {
        transform.localScale += Vector3.up * _chainSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            PlayerController.score++;
            other.GetComponent<BallController>().Split();
            Destroy(other.gameObject);
        }


        PlayerController.canFire = true;
        Destroy(gameObject);
    }
}
