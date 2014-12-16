using UnityEngine;
using System.Collections;



public class Player : MonoBehaviour 
{

    private GameController controller;

    private float delayTime = 0;



	void Start() 
	{

		controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();
	
	}


    void Update()
    {

        if( delayTime > 0 ){

            delayTime -= Time.deltaTime;

        }

    }
	

    void OnTriggerEnter( Collider col )
    {

        if( col.tag == "EnemyWepon" && delayTime <= 0 ){

            controller.SendMessage( "Damage", col.GetComponent< Wepon >().attack );

            delayTime = 0.5f;

        }

    }

}