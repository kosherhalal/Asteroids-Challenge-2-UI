using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Text : MonoBehaviour {

	TextMesh text;

    //Points Manager Constructor
	Points_Manager points;

	[Tooltip("Set this in editor with the Points_Manager Gameobject")]
	public GameObject PointsManager; 
	// Use this for initialization
	void Start ()
    {
		text = GetComponent<TextMesh>();

		points = PointsManager.GetComponent<Points_Manager>(); 

	}
	
	// Update is called once per frame
	void Update ()
    {
        //update UI text mesh in update
        text.text = points.Points.ToString(); 
        
	}
}
