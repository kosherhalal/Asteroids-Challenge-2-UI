using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Manager : MonoBehaviour {

    //Animator reference 
	Animator anim;

    //set the amount of time before we
    //reload the scene
	public float restartDelay = 5f;

    //restart timer var
    //we will start incrementing this
    //after the gameOver critera is met 
	float restartTimer;

    //refence to Jump_Manager Class
    [Tooltip("Set this to the PlayerShip GameObject in the Editor")]
	public Jump_Manager jump_Manager; 

    // Use this for initialization
	void Start ()
    {
        //init the anim reference
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        //if gameOver is true 
        if(jump_Manager.gameOver)
        {
            //trigger GameOVer Animation
			anim.SetTrigger("GameOver");

            //start incrementing restart timer
			restartTimer += Time.deltaTime;

            //when restart timer equals our set delay
			if (restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}



		}


	}
}
