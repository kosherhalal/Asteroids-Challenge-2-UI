using System.Collections;
using UnityEngine;
using UnityEngine.Events; 


public class Points_Manager : MonoBehaviour {

    //Crete new instance of ASteroidobject script,
    //we will use this to access the pointsForAsteroidsSizeArray
    AsteroidsScriptableObject asteroid_SO;


    #region Private values
    //private points value
    private int points = 0;

    #endregion



    #region Properties
    /// <summary>
    /// public property to access points (hopefully for UI)
    /// </summary>
    public int Points
    { 
        get{ return points; }
    }

    #endregion

    private void Start()
    {
        //constructor for accessing AsteroidsScrip
        asteroid_SO = new AsteroidsScriptableObject(); 
    }
    /// <summary>
    /// event trigger that calls PointsHandling
    /// </summary>
    void OnEnable()
        {
         
            Points_Event.BulletHitAsteroid += PointsHandling;
            
        }
   
        //unsubscribes to event after calling 
        //this needs to happen or else event will be continually called
    void OnDisable()
        {
            Points_Event.BulletHitAsteroid -= PointsHandling;
        }



    /// <summary>
    /// Function is triggered by event and takes
    /// a string input from the asteroid name that detected the
    /// collision with a bullet and detects the relevant size by detecting
    /// '_' in the asteroid name **See line 78 in the AsteraX script** for code that assigns name
    /// Its an interesting way to see what size has currently been hit :)
    /// </summary>
    /// <param name="asteroidName"></param>
        void PointsHandling(string asteroidName)
        {
            //counter for each special char we find in the name string 
            int count = 0;

            //search current asteroid name string
            //to find char that show the current asteroid level
            //We search for '_' char which corresponds to the size
            //of the asteroid 
            foreach(char x in asteroidName)
            {
                //if char is found 
                if(x == '_')
                {
                    //add to count
                    count += 1; 

                }
                
            }

        //assign pointsValue var by passing the count to
        //AsteroidSizePointValue Function
        var pointsValue = AsteroidSizePointValue(count);

        
       
            //increment points based on asteroid size
            //remember points is a private int, but is the "get" for our public
            //property Points, so when we need to update the UI we can access it
            points += pointsValue;
        

            //Debugging 
            Debug.Log(points);
            
        }
    ////
    ///





    /// <summary>
    /// Switch statement that takes input from the special character count
    /// and will find the corresponding size and point value to return
    /// we access the pointsForAsteroid array (from the AsteroidsScriptableObject script)
    /// and return the corresponding point value 
    /// </summary>
    /// <param name="c"></param>
    /// <returns>Points value based on asteroid size 3 -> 1</returns>
    int AsteroidSizePointValue(int c)
        {
            switch(c)
            {

            case 1:  { return asteroid_SO.pointsForAsteroidSize[3]; }

            case 2: { return asteroid_SO.pointsForAsteroidSize[2]; }

            case 3: { return asteroid_SO.pointsForAsteroidSize[1]; }
                //invalid count 
            default: return asteroid_SO.pointsForAsteroidSize[0]; 

            }


        }

        /// <summary>
        /// returns Point value for asteroid size from a SO
        /// </summary>



  



    
}
