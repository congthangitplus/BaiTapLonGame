using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class destroy : MonoBehaviour {

    public Text ScoreText;
    int score = 0;
    public static int highScore, myScore = 0;
    public Text HighScoreText;

    // Use this for initialization
    void Start () {
        StarGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StarGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            // 4
            highScore = Save.score;
            HighScoreText.text = "High Score: " + highScore.ToString();
            //min = save.min;
            //minText.text = min.ToString();
            //nb1 = save.nb1;
            //nb1Text.text = nb1.ToString();
            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "barriercar")
        {

            Destroy(col.gameObject);
            Upscore();
        }

        if (col.gameObject.tag == "itemNgang" || col.gameObject.tag == "itemDoc")
        {
            Destroy(col.gameObject);
        }
    }

    void Upscore()
    {

        score++;
        ScoreText.text = "Score: " + score.ToString();
        myScore = score;
    }
    
}
