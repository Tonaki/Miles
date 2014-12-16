using UnityEngine;
using System.Collections;



public class GameController : SingletonMonoBehaviour< GameController >
{

	public int hp = 100;

	public int maxHp = 100;


	// Use this for initialization
	void Start () 
	{

		DontDestroyOnLoad( this.gameObject );

		maxHp = hp;
		
	}
	
	// Update is called once per frame
    //void Update () 
    //{

    //    //if( Input.GetMouseButtonDown( 0 ) ){

    //    //    hp -= 1;

    //    //}

    //}

    void Damage( int damage )
    {

        hp -= damage;

        if( hp < 0 ){

            hp = 0;

        }

    }

}