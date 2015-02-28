using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	public int hp = 0;

	public bool maltiPoint = true;

	public GameObject efect = null;

	private GameObject player = null;

	private float interval = 0.0f;



	// Use this for initialization
	void Start () 
	{

        //if( efect != null ){

        //    Instantiate( efect, gameObject.transform.position, efect.transform.rotation );

        //}

		player = GameObject.FindWithTag( "Player" );

		if( player != null ){

			iTween.LookTo( gameObject, player.transform.position, 1 );

		}
	
	}

	void OnTriggerEnter( Collider col )
	{

		if( maltiPoint == true || interval > Time.timeSinceLevelLoad ){

			return;

		}

		if( col.tag == "Wepon" ){

            interval = Time.timeSinceLevelLoad + 0.5f;

			Damage( 1 );

		}

	}
	
	void Damage( int point )
	{

		hp -= point;

		if( hp <= 0 && gameObject.tag != "CutObject" ){

            gameObject.tag = "CutObject";

            Destroy( gameObject, 5.0f );

		}

	}

}