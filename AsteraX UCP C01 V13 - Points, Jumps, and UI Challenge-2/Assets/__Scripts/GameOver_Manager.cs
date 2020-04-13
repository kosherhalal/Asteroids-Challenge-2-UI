using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Manager : MonoBehaviour {

	public GameObject playerShip;

	Animator anim;

	public float restartDelay = 5f;

	float restartTimer;

	Jump_Manager jump_Manager; 
    // Use this for initialization
	void Start () {

		jump_Manager = playerShip.GetComponent<Jump_Manager>();

		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(jump_Manager.gameOver)
        {

			anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay)
			{
				// .. then reload the currently loaded level.
				Application.LoadLevel(Application.loadedLevel);
			}



		}


	}
}
