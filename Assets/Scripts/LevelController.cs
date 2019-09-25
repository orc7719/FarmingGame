using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TMP_Text timer;

    //change the time longer or shorter (convert into seconds E.G 3minuits 180 seconds)
    float gametimer = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this countdowns the time.
        gametimer -= Time.deltaTime;

         
        int seconds = (int)(gametimer % 60); //converts to seconds
        int minutes = (int)(gametimer / 60) % 60; //converts to minuits
        

        string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);

        timer.text = timerString;

    }
}
