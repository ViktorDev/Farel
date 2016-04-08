/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class CustomTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            //Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            //Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            //// Enable rendering:
            //foreach (Renderer component in rendererComponents)
            //{
            //    component.enabled = true;
            //}

            //// Enable colliders:
            //foreach (Collider component in colliderComponents)
            //{
            //    component.enabled = true;
            //}

            SceneStateManager.instance.curentManager.SetActive(true);

            //VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();
            //if (video != null && video.AutoPlay)
            //{
            //    if (video.VideoPlayer.IsPlayableOnTexture())
            //    {
            //        VideoPlayerHelper.MediaState state = video.VideoPlayer.GetStatus();
            //        if (state == VideoPlayerHelper.MediaState.PAUSED ||
            //            state == VideoPlayerHelper.MediaState.READY ||
            //            state == VideoPlayerHelper.MediaState.STOPPED)
            //        {
            //            // Pause other videos before playing this one
            //            PauseOtherVideos(video);

            //            // Play this video on texture where it left off
            //            video.VideoPlayer.Play(false, video.VideoPlayer.GetCurrentPosition());
            //        }
            //        else if (state == VideoPlayerHelper.MediaState.REACHED_END)
            //        {
            //            // Pause other videos before playing this one
            //            PauseOtherVideos(video);

            //            // Play this video from the beginning
            //            video.VideoPlayer.Play(false, 0);
            //        }
            //    }
            //}

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            //Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            //Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            //// Disable rendering:
            //foreach (Renderer component in rendererComponents)
            //{
            //    component.enabled = false;
            //}

            //// Disable colliders:
            //foreach (Collider component in colliderComponents)
            //{
            //    component.enabled = false;
            //}
            if(!SceneStateManager.instance.isSelfieMode)
            SceneStateManager.instance.curentManager.SetActive(false);
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        //private void PauseOtherVideos(VideoPlaybackBehaviour currentVideo)
        //{
        //    VideoPlaybackBehaviour[] videos = (VideoPlaybackBehaviour[])
        //            FindObjectsOfType(typeof(VideoPlaybackBehaviour));

        //    foreach (VideoPlaybackBehaviour video in videos)
        //    {
        //        if (video != currentVideo)
        //        {
        //            if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
        //            {
        //                video.VideoPlayer.Pause();
        //            }
        //        }
        //    }
        //}
        #endregion // PRIVATE_METHODS
    }
   
}
