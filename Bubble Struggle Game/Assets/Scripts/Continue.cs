using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{

    [SerializeField] private Text _score;
    [SerializeField] private string _mainMenu = "Main_Menu";


    private void Start()
    {
        StartCoroutine(ScoreAnim());
    }

    private IEnumerator ScoreAnim()
    {
        int temp = 0;

        while(temp <= PlayerController.score)
        {
            _score.text = temp.ToString();
            temp++;
            yield return new WaitForSeconds(.05f);
        }

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
