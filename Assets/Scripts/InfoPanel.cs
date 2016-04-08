using UnityEngine;
using System.Collections;

public class InfoPanel : MonoBehaviour 
{
	public RectTransform panel;
    public GameObject videoPanel;
    VideoPlaybackBehaviour video;


    void OnEnable() {
        video = videoPanel.GetComponent<VideoPlaybackBehaviour>();
    }
    
    private void PauseOtherVideos(VideoPlaybackBehaviour currentVideo)
    {
        VideoPlaybackBehaviour[] videos = (VideoPlaybackBehaviour[])
                FindObjectsOfType(typeof(VideoPlaybackBehaviour));

        foreach (VideoPlaybackBehaviour video in videos)
        {
            if (video != currentVideo)
            {
                if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    video.VideoPlayer.Pause();
                }
            }
        }
    }

    public void OpenPanel() 
	{
        
        StartCoroutine(Open());
        videoPanel.SetActive(true);
    }

    public void showVideo() {
        
//        video.VideoPlayer.Init(true);
        if (video != null)
        {
            if (video.VideoPlayer.IsPlayableOnTexture())
            {
                VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
                if (state == VideoPlayerHelper.MediaState.PAUSED ||
                    state == VideoPlayerHelper.MediaState.READY ||
                    state == VideoPlayerHelper.MediaState.STOPPED)
                {
                    //                   Pause other videos before playing this one
                    PauseOtherVideos(video);
 //                  video.VideoPlayer.SetFilename("Unity 5 Launch Trailer.mp4");
                    //                   Play this video on texture where it left off
                    video.VideoPlayer.Play(false, 0);
                }
                else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                {
                    // Pause other videos before playing this one
                    PauseOtherVideos(video);
//                    video.VideoPlayer.SetFilename("Unity 5 Launch Trailer.mp4");
                    // Play this video from the beginning
                    video.VideoPlayer.Play(false, 0);
                }
                
            }
        }

        
    }

	public void ClosePanel() 
	{
        videoPanel.SetActive(false);
        //        video.VideoPlayer.Stop();
        //        video.VideoPlayer.Deinit();
        StartCoroutine(Close());
        
    }

	IEnumerator Open() {
        
        while (panel.localScale.y < 1f) {
			panel.localScale = new Vector3(1, panel.localScale.y + 0.05f, 1);
			yield return new WaitForSeconds(0.01f);
		}
		panel.localScale = new Vector3(1, 1f, 1);

        
    }

	IEnumerator Close()
	{
        while (panel.localScale.y>0)
		{
			panel.localScale = new Vector3(1, panel.localScale.y - 0.05f, 1);
			yield return new WaitForSeconds(0.01f);
		}
		panel.localScale = new Vector3(1, 0, 1);       
        gameObject.SetActive(false);
	}
}
