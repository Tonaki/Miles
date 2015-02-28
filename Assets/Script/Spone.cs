using UnityEngine;
using System.Collections;

public class Spone : MonoBehaviour 
{


	public GameObject popEnemy = null;

	public Vector3 popPosition;

    private GameController controller;


    void Start () 
    {

        controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();

    }

	void OnTriggerEnter( Collider col )
	{

		if( popEnemy != null ){

            controller.PlayBGM( 2 );

			Instantiate( popEnemy, popPosition, popEnemy.transform.rotation );

			Destroy( gameObject );

		}

	}
	
}