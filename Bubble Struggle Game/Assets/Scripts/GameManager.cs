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
    [SerializeField] private GameObject _continueScreen;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
      
        StartCoroutine(BallCounter());
    }

    void Start()
    {
    }

    void Update()
    {
        _scoreText.text = PlayerController.score.ToString();

        if (BallController.ballCount <=0)
        {
            _continueScreen.SetActive(true);
            print("level won");
        }
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }

    // To count the number of balls currently active; So as to open the Continue UI
    private IEnumerator BallCounter()
    {
        BallController.ballCount = GameObject.FindObjectsOfType<BallController>().Length;
        print(BallController.ballCount);

        yield return new WaitForSeconds(1f);
        StartCoroutine(BallCounter());
    }
}
