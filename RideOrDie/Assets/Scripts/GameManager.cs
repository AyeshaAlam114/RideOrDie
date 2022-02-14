using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public Text textField;
    public GameObject[] pannelsArray;
    public Text scoreField;
    public ScoreManager refSM;

    public bool perfectLanding;

    void Start()
    {
        refSM = new ScoreManager();
        gameOver = false;
        Time.timeScale = 1;
        AllPannelDeactive();
    }
  

    public void PerfectlyLand()
    {
        perfectLanding = true;
    }
    public bool Getperfectlanding()
    {
        return perfectLanding ;
    }
    public void Setperfectlanding(bool state)
    {
        perfectLanding=state;
    }


    void PannelActive(int a)
    {
        AllPannelDeactive();
        pannelsArray[a].SetActive(true);
    }
    void AllPannelDeactive()
    {
        foreach (GameObject z in pannelsArray)
            z.SetActive(false);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        textField.GetComponent<Text>().text = "GAME OVER!";
        PannelActive(0);
    }


    public void GameEnd()
    {
        Time.timeScale = 0;
        textField.GetComponent<Text>().text = "GAME END!";
        PannelActive(0);
    }

     public void TrafficCrash()
    {
        Time.timeScale = 0;
        textField.GetComponent<Text>().text = "TRAFFIC CRASH!";
        PannelActive(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }

}
