using UnityEngine;
using System.Collections;

public class PlayVideoVuforia : MonoBehaviour {

	// Use this for initialization
	void Start () {
        VideoPlaybackBehaviour video = GetComponent<VideoPlaybackBehaviour>();
        if (video != null && video.AutoPlay)
        {
            if (video.VideoPlayer.IsPlayableOnTexture())
            {
                VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
                if (state == VideoPlayerHelper.MediaState.PAUSED ||
                    state == VideoPlayerHelper.MediaState.READY ||
                    state == VideoPlayerHelper.MediaState.STOPPED)
                {
                    // Pause other videos before playing this one
//                    PauseOtherVideos(video);

                    // Play this video on texture where it left off
                    video.VideoPlayer.Play(false, video.VideoPlayer.GetCurrentPosition());
                }
                else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                {
                    // Pause other videos before playing this one
//                    PauseOtherVideos(video);

                    // Play this video from the beginning
                    video.VideoPlayer.Play(false, 0);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
