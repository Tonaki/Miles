using UnityEngine;
using System.Collections;



namespace FCamera
{

    public class Fade : MonoBehaviour 
    {

        public Texture2D texture;

        public Texture2D startMask, endMask;

        [ Range( 0, 3 ) ]
        public float fadeinTime = 0.4f, fadeoutTime = 1.4f;


        
    	public void LoadLevel( int nextScene ) 
        {

            FadeCamera.Instance.UpdateTexture( texture );
            FadeCamera.Instance.UpdateMaskTexture( startMask );
            FadeCamera.Instance.FadeOut( fadeinTime, () =>
                {

                    Application.LoadLevel( nextScene );
                    FadeCamera.Instance.UpdateMaskTexture( endMask );
                    FadeCamera.Instance.FadeIn( fadeoutTime, null );

                } );
    	
    	}
    
    }
    
}