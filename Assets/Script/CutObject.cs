using UnityEngine;
using System.Collections;



public class CutObject : MonoBehaviour 
{

	public int hp = 0;

	public bool breakPoint = false;

	private float interval = 0.0f;

	private GameObject parent = null;


	// Use this for initialization
	void Start () 
	{

		parent = gameObject.transform.parent.gameObject;

	}

	void OnTriggerEnter( Collider col )
	{

		if( interval > Time.timeSinceLevelLoad ){

			return;

		}

		if( col.tag == "Wepon" ){

            interval = Time.timeSinceLevelLoad + 0.5f;

			if( breakPoint == false ){

				parent.GetComponent< Enemy >().SendMessage( "Damage", 1 );

                return;

			}

            Damage( 1 );

		}

	}

    void Damage( int point )
	{

		hp -= point;

		if( hp <= 0 && gameObject.tag != "CutObject" ){

            gameObject.tag = "CutObject";

            //Destroy( gameObject, 1.0f );

		}

	}

}