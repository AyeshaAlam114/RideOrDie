using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameManager refGM;
    public int increasingMultiple;

    private void Update()
    {
        if (!GameManager.gameOver&& refGM.Getperfectlanding())
        {
            IncreaseScore();
            refGM.Setperfectlanding(false);
        }
    }
    int ConvertScoreToInt()
    {
        return int.Parse(refGM.scoreField.GetComponent<Text>().text);
    }
    void DisplayScore(int score)
    {
        refGM.scoreField.GetComponent<Text>().text = score.ToString();
    }
    public void IncreaseScore()
    {
        int scoreInt = ConvertScoreToInt();
        scoreInt*= increasingMultiple;
        DisplayScore(scoreInt);
    }

  
    public int GetScore()
    {
        return ConvertScoreToInt();       
    }

}
