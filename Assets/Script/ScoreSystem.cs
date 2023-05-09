using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    public const string HighScoreKey = "High Score";
    private float score;

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime*scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy() {
        int CurrentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > CurrentHighScore){
            PlayerPrefs.SetInt(HighScoreKey,Mathf.FloorToInt(score));
        }
    }
}
