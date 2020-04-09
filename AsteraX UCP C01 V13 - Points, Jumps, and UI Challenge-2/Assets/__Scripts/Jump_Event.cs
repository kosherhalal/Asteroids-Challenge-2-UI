using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump_Event : MonoBehaviour {
	
    
    /// <summary>
	/// Event system that will trigger when the Players spaceship collides with an asteroid
	/// this will be used to deduct player jumps(or lives) and initalize the random jump to a safe place on screen
	/// and deduct lives until the Gameover 
	/// </summary>

     
    
    //Delegate  for Collisions with the ship 
    public delegate void ShipAsteroidCollision();
	//public event 
	public static event ShipAsteroidCollision OnCollisionAsteroid;

    //cache colliding gameobject name to prevent duplicate collisions triggering from
    // a Asteroid hit
	private string gameObjNameCache = ""; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}


    //Called when Ship collides with another collider Object
	private void OnCollisionEnter(Collision collision)
	{

        
        //if collision with ship is the Asteroid tag AND gameObject name dones not match previously hit Asteroid. 
		if (collision.gameObject.layer == 10 &&  collision.gameObject.name != gameObjNameCache)
        {
            //DEBUG 
            //Debug.Log("Jumping to safe location" + collision.gameObject.name);

            //cache current collision gameObject name to prevent repeat collisions Because
            //Collisions are sent up the chain to the parent 
			gameObjNameCache = collision.gameObject.name;

            //trigger event for collision with asteroid
			OnCollisionAsteroid();
          
        }

	}


}
