using UnityEngine;
using System.Collections;



public class Goblin : MonoBehaviour 
{

    private Animator animator;

    private bool attackMode = false;

    private const float delay = 60.0f;

    private float attackDelay = delay;

    
	// Use this for initialization
	void Start() 
    {

        animator = gameObject.GetComponent< Animator >();

	}

    void Update()
    {

    }

    void OnTriggerEnter( Collider col )
    {

        if( col.tag == "Player" ){

            animator.SetTrigger( "AttakMode" );

            iTween.LookTo( gameObject, col.gameObject.transform.position, 1 );

        }

    }

    void OnTriggerStay( Collider col )
    {

        if( col.tag == "Player" ){

            iTween.LookTo( gameObject, col.gameObject.transform.position, 1 );

            if( attackDelay <= Random.Range( 0, ( int )delay - 2 ) ){

                animator.SetTrigger( "Attak" );

                attackDelay = delay;

            }

            attackDelay -= Time.deltaTime;

        }

    }

    void OnTriggerExit( Collider col )
    {

        if( col.tag == "Player" ){

            animator.SetTrigger( "IdleMode" );

            attackDelay = delay;

        }

    }

}