using UnityEngine;
using System.Collections;



public class GameController : SingletonMonoBehaviour< GameController >
{

	public int maxHp = 100;

    public int hp = 100;


	// Use this for initialization
	void Start () 
	{

		DontDestroyOnLoad( this.gameObject );

		hp = maxHp;
		
	}
	
	// Update is called once per frame
    void Update () 
    {

        if( Input.GetKeyDown( KeyCode.Escape ) ){

            Application.Quit();

        }

    }

    void Damage( int damage )
    {

        hp -= damage;

        if( hp <= 0 ){

			gameObject.GetComponent< FCamera.Fade >().LoadLevel( 0 );

            hp = 100;

        }

    }

}