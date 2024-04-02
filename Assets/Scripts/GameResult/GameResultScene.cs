using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameResultScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    private void OnEnable()
    {
        scoreText.text = game.TimeManager.instance.score.ToString();
        perfectText.text = game.TimeManager.instance.perfect.ToString();
        greatText.text = game.TimeManager.instance.great.ToString();
        badText.text = game.TimeManager.instance.bad.ToString();
        missText.text = game.TimeManager.instance.miss.ToString();
    }

    public void Retry()
    {
        game.TimeManager.instance.perfect = 0;
        game.TimeManager.instance.great = 0;
        game.TimeManager.instance.bad = 0;
        game.TimeManager.instance.miss = 0;
        game.TimeManager.instance.maxScore = 0;
        game.TimeManager.instance.ratioScore = 0;
        game.TimeManager.instance.score = 0;
        game.TimeManager.instance.combo = 0;
        SceneManager.LoadScene("GameScene");
    }
}
