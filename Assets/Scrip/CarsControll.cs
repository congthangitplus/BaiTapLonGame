using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CarsControll : MonoBehaviour {

    public float carSpeed, jumpPow = 220f;
    public float maxPoa = 18.4f;
    Vector2 position;
    public Uimaneger ui;
    public MusicManeger am;
    public Text score;
    public bool lines;
    int scores = 0;
    public Rigidbody2D r2;
    int chieuNgang = 1, chieuDoc=1;
    float timeEffect;
    float startTime;
    public float TT = 1f, GT = 1f;
    public static float TT1,GT1;
    public int highScore;



    //public Carspaner ac;

    //void Upscore()
    //{

    //    scores++;
    //    score.text = "Score: " + scores.ToString();

    //}
    //void dk()
    //{
    //    if (position.y >= Carspaner.cad)
    //    {
    //        Upscore();
    //    }
    //}

    public void Awake()
    {
        am.carSound.Play();
    }
    // Use this for initialization
    void Start()
    {
        //ui = GetComponent<Uimaneger> ();
        position = transform.position;
    }

    // Update is called once per frame
    void Update() {

        MoveCar(chieuNgang,chieuDoc);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (lines)
        //    {

        //        r2.AddForce(Vector2.up * jumpPow);
        //    }
        //}

        timeEffect -= Time.deltaTime;
        CheckTimeEffectItem();
    }

    void MoveCar(int chieuNgang, int chieuDoc)
    {
        // xe di chuyển qua trái phải
        position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime * chieuNgang;
        position.x = Mathf.Clamp(position.x, -18.4f, 18.4f);
        position.y += Input.GetAxis("Vertical") * carSpeed * Time.deltaTime * chieuDoc;
        position.y = Mathf.Clamp(position.y, -3.7f, 52.8f);
        transform.position = position;
        //end
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "barriercar")
        {

            Destroy(gameObject);
            ui.gameOverActivated();
            ui.menubutton();
            am.carSound.Stop();

            //điểm 
            Save save = CreateSaveGameObject();
            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
            bf.Serialize(file, save);
            file.Close();
            // 3
            ////destroy.hightScore = 0;
            Debug.Log("Game Saved");
        }
        
        if (col.gameObject.tag == "itemNgang")
        {
            Destroy(col.gameObject);
            chieuNgang = -1;
            timeEffect = 5f;
        }

        if (col.gameObject.tag == "itemDoc")
        {
            Destroy(col.gameObject);
            chieuDoc = -1;
            timeEffect = 5f;
        }

        if (col.gameObject.tag == "itemTT")
        {
            Destroy(col.gameObject);
            TT = 5f;
            TT1 = TT;
            timeEffect = 5f;
        }
        if (col.gameObject.tag == "itemGT")
        {
            Destroy(col.gameObject);
            GT = -3f;
            GT1 = GT;
            timeEffect = 5f;
        }
    }

    void CheckTimeEffectItem ()
    {
        if (timeEffect <= 0)
        {
            chieuNgang = 1;
            chieuDoc = 1;
            TT1 = 1;
            GT1 = 1;
        }
    }

    public Save CreateSaveGameObject()
    {
        Save save = new Save();
        if(Save.score < destroy.myScore)
            Save.score = destroy.myScore;
        //save.min = min;
        //save.nb1 = nb1;
        return save;
    }
}
