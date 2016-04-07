using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour 
{
	public void PlayClip()
	{
		//StartCoroutine (Start ());
		Handheld.PlayFullScreenMovie ("Unity 5 Launch Trailer.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		Debug.Log ("Play");
	}

/*	IEnumerator Start()
	{
		Handheld.PlayFullScreenMovie ("Unity 5 Launch Trailer.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);

		yield return null;

		print ("Move Scene");
	}*/
}
