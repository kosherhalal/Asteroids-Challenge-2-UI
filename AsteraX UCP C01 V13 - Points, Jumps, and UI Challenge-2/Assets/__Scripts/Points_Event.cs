using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event system that will trigger when a bullet (Layer 9) hits an asteroid
/// This will be used for detecting and adding points 
/// </summary>

public class Points_Event : MonoBehaviour {

    //event Delegate
    public delegate void OnBulletHitAsteroid(string asteroidName);
    //public event 
	public static event OnBulletHitAsteroid BulletHitAsteroid;


    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //trigger when collision happens 
    private void OnCollisionEnter(Collision collision)
    {
        //if collision with Bullet occurs 
        if(collision.gameObject.layer == 9 )
        {
            
            //Event trigger 
			BulletHitAsteroid(gameObject.name);
            
        }

    }
}
