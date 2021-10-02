/*=======================================================================*/
/*  This script keeps tracked of the game score and keeps the highscore  */
/*=======================================================================*/


using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _highScoreText;

    private static int _highScore = 0;

    private int _score = -1; // so it starts from 0

    private void Start()
    {
        _highScore = (SaveData.current.PlayerHS != null) ? SaveData.current.PlayerHS.HighScore : 0;

        PlayerActions.instance.OnScoreGain += UpdateScoreText;
        PlayerActions.instance.OnDeath += ShowHighScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        _score++;
        _scoreText.text = _score.ToString();

        if (_score > _highScore)
            _highScore = _score;
    }

    void ShowHighScore()
    {
        // Save highscore
        SaveData.current.PlayerHS.HighScore = _highScore;

        string text = $"Your High Score is: {_highScore}\nYour Current Score is: {_score}";
        _highScoreText.text = text;
    }

    private void OnDisable()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
    }
}
