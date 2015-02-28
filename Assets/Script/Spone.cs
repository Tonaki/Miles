using UnityEngine;
using System.Collections;

public class Spone : MonoBehaviour 
{


	public GameObject popEnemy = null;

	public Vector3 popPosition;



	void OnTriggerEnter( Collider col )
	{

		if( popEnemy != null ){

			Instantiate( popEnemy, popPosition, popEnemy.transform.rotation );

			Destroy( gameObject );

		}

	}
	
}