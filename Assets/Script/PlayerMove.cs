using UnityEngine;
using System.Collections;



public class PlayerMove : MonoBehaviour 
{

	public GameObject[] target = null;

	private int targetNum = 0;

	private GameObject Active = null;

	private GameObject player = null;

	private NavMeshAgent agent = null;


	// Use this for initialization
	void Start ()
	{

		player = gameObject.transform.parent.gameObject;

		agent = gameObject.transform.parent.gameObject.GetComponent< NavMeshAgent >();

		Active = target[ targetNum ];

		agent.SetDestination( target[ targetNum ].transform.position );
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if( Active == null ){

			agent.Stop();

			Active = target[ targetNum ];

			agent.SetDestination( Active.transform.position );

		}

        //Debug.DrawLine( player.transform.position, agent.destination );

        //Debug.DrawLine( player.transform.position, target[ targetNum ].transform.position, new Color( 0, 0, 255 ) );

        Debug.DrawLine( player.transform.position, Active.transform.position, new Color( 255, 0, 0 ) );

        //Debug.Log( agent.hasPath );

		if( Vector3.Distance( player.transform.position,  target[ targetNum ].transform.position ) <= 2.0f ){

			agent.Stop();

			if( targetNum < target.Length ){

				targetNum += 1;

			}

			Active = target[ targetNum ];

			agent.SetDestination( Active.transform.position );

		}
	
	}


	void OnTriggerStay( Collider col )
	{

		if( col.transform.gameObject.tag == "Enemy" ){

			float playerToActiveTarget = Vector3.Distance( player.transform.position, Active.transform.position );

			float playerToEnemy = Vector3.Distance( player.transform.position, col.transform.gameObject.transform.position );

			if( playerToActiveTarget > playerToEnemy ){

				agent.Stop();

				Active = col.transform.gameObject;

				iTween.LookTo( player, col.transform.gameObject.transform.position, 1.0f );

				agent.SetDestination( Active.transform.position );

			}

		}

	}

}