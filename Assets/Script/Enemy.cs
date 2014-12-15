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

		if( efect != null ){

			Instantiate( efect, gameObject.transform.position, efect.transform.rotation );

		}

		player = GameObject.FindWithTag( "Player" );

		if( player != null ){

			iTween.LookTo( gameObject, player.transform.position, 1 );

		}
	
	}


	void OnTriggerEnter( Collider col )
	{

		if( interval > Time.timeSinceLevelLoad ){

			return;

		}

		if( maltiPoint == true ){

			return;

		}

		if( col.tag == "Wepon" ){

			hp -= 1;

			if( hp <= 0 && gameObject.tag != "CutObject" ){

				gameObject.tag = "CutObject";

			}

			interval = Time.timeSinceLevelLoad + 0.3f;

		}

	}
	

	void Damage( int point )
	{

		hp -= point;

		if( hp <= 0 ){

			Destroy( gameObject, 4.0f );

		}

	}

}