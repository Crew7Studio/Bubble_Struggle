using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _continueScreem;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
    }

    void Start()
    {
        BallController.ballCount = 1;
    }

    void Update()
    {
        _scoreText.text = PlayerController.score.ToString();

        print(BallController.ballCount);
        if (BallController.ballCount <=0)
        {
            _continueScreem.SetActive(true);
            print("level won");
        }
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }
}
