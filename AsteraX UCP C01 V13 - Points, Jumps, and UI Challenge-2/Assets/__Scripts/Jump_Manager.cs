using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO
/// NEED to debug the jumpsAvailable counter
/// deductions are not working properly
/// </summary>

public class Jump_Manager : MonoBehaviour
{
    AsteraX asteraX;

    //Jumps available
    [Tooltip("Set in editor")]
    public int Jumps = 5;
    
    //Safe distance check for jump locaction from surrounding asteroids
    const float MIN_PLAYER_SHIP_JUMP_LOCATION_FROM_ASTEROIDS = 5;

    

    #region private fields 

    //stores the amount of jumps left
    //this is protected and is not accessable out side
    //of this class
    //we will use the jumpsAvailable property
    private int jumpsLeft;

    //private game over bool 
    private bool isGameOver = false;


    #endregion

    #region Constructor
    public Jump_Manager(int jumpsLeft)
    {

        this.jumpsLeft = jumpsLeft; 

    }
    #endregion


    #region Public Properties
    //public property to check if Jumps are depleted
    //and gameOver criteria are met
    public bool gameOver
    {
        get
        {
            return isGameOver;
        }
    }


    public int JumpsLeft
    {

        get
        {
            return jumpsLeft; 
        }

    }
    /// <summary>
    /// Public Properties
    /// </summary>
    #endregion


    private void Start()
    {
        //set jumpsLeft to jumps 
        jumpsLeft = Jumps;
    }



    void OnEnable()
    {
        
        Jump_Event.OnCollisionAsteroid += HandleAsteroidCollision;
        //Jump_Event.OnCollisionAsteroid -= HandleAsteroidCollision;
    }

    void OnDisable()
    {
        Jump_Event.OnCollisionAsteroid -= HandleAsteroidCollision;
    }

    void HandleAsteroidCollision()
    {

        //when collision is detected and
        //event is triggered, subtract one from
        //jumps left
        jumpsLeft -= 1;

        //if jumps are available or last
        //jump is used up 
        if (jumpsLeft >= 0)
        {

            Debug.Log(JumpHandler());

            //NEED TO USE A COROUTINE for delay and set ship as INACTIVE for a few seconds
            gameObject.transform.position = JumpHandler(); 


            Debug.Log("Total Jumps Left : " + jumpsLeft); 

        }
        else
        {
            //set gameover flag as true when lives are done
            //need to link this with the ENum state FLAGS
            isGameOver = true; 

        }



        
    }

    Vector3 JumpHandler()
    {
        Vector3 pos;
        Vector3 asteroidPosition;
        int i = 0;
        

        //check if random on screen location is a safe distance from asteroids
        do
        {
            //grab random location 
            pos = ScreenBounds.RANDOM_ON_SCREEN_LOC;

            //get position from asteroid List 
            asteroidPosition = AsteraX.ASTEROIDS[i].transform.position; 

            Debug.Log("Searching for a safe Jump");

            i += 1; 

            //search for a position thats distance from the playership Keep looping if the position is less than the set distance and break when found
        } while ((pos - asteroidPosition).magnitude < MIN_PLAYER_SHIP_JUMP_LOCATION_FROM_ASTEROIDS);

        //reset counter 
        i = 0;

        return pos; 
    }


}
