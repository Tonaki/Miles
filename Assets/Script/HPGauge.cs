using UnityEngine;
using System.Collections;

public class HPGauge : MonoBehaviour 
{

	private GameController controller;

	private float hpScale = 1.0f;

	// Use this for initialization
	void Start () 
	{

		controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();

		hpScale = ( float )controller.hp / controller.maxHp;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if( hpScale != ( float )controller.hp / controller.maxHp ){

			hpScale = ( float )controller.hp / controller.maxHp;
			
			Vector3 buf;
			
			buf.x = hpScale;
			buf.y = gameObject.transform.localScale.y;
			buf.z = gameObject.transform.localScale.z;
			
			gameObject.transform.localScale = buf;

		}
	
	}

}
