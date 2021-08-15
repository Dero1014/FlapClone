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
        PlayerActions.instance.OnScoreGain += UpdateScoreText;
        PlayerActions.instance.OnDeath += ShowHighScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    void ShowHighScore()
    {
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
