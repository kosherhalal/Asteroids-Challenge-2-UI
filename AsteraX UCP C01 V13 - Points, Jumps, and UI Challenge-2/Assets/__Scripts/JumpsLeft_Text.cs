using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpsLeft_Text : MonoBehaviour {


    TextMesh text;

    int jumpsAvailable;

    Jump_Manager jumpManager;

    [Tooltip("Set in Editor to the PlayerShip Gameobject that has the Jump Manager Component")]
    public GameObject JumpManager; 

    void Start()
    {
        text = GetComponent<TextMesh>();
        // Set the text of the attached Text mes


        jumpManager = JumpManager.GetComponent<Jump_Manager>(); 
        
        
    }


    private void Update()
    {
        //set text to jumps left from the JumpManager
        //since we used a static variable we do not need to
        // use a GetComponent<> and init a new instance of the class
        //text.text = "Jumps Left " + Jump_Manager.jumpsLeft.ToString();

        text.text = "Jumps Left " + jumpManager.JumpsLeft.ToString(); 



    }

}



