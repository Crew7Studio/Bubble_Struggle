using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private Text _scoreText;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
    }

    void Start()
    {

    }

    void Update()
    {
        _scoreText.text = PlayerController.score.ToString();
    }
}
