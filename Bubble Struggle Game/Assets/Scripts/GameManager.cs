using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _lifeText;
    [SerializeField] private int _initialLife = 2;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _continueScreen;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _spawner;


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
        _lifeText.text ="X " + PlayerController._lifeCount;

        if (BallController.ballCount <=0)
        {
            _continueScreen.SetActive(true);
            print("level won");
        }

        // If continue or game over screen is active then do show pause menu
        if(_continueScreen.activeSelf || _gameOverScreen.activeSelf)
        {
            _pauseMenu.SetActive(false);
            _spawner.SetActive(false);
        }
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
        ResetLife();
    }

    // To count the number of balls currently active; So as to open the Continue UI
    private IEnumerator BallCounter()
    {
        BallController.ballCount = GameObject.FindObjectsOfType<BallController>().Length;
        print(BallController.ballCount);

        yield return new WaitForSeconds(1f);
        StartCoroutine(BallCounter());
    }

    private void ResetLife()
    {
        PlayerController._lifeCount = _initialLife;
    }
}
