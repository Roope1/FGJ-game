using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string _playScene;
    [SerializeField] private TMP_Text _highScore;

    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScore.SetText($"High Score: {highScore}");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene(_playScene);

    }


    public void Quit()
    {
        Application.Quit();
    }
}
