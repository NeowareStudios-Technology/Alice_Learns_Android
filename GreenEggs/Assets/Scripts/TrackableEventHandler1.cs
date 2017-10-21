/*============================================================================== 
 * Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class TrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBERS
    private TrackableBehaviour mTrackableBehaviour;
    private bool mHasBeenFound = false;
    private bool mLostTracking;
    private float mSecondsSinceLost;
    public GameObject p89, p1011, p1213, p1415, p1617, p1819, p2021, p2223, p2425, p2627, p2829, p3031, p3233, p3435, p3637, p3839, p4041, p4243, p4445, p4647, p4849, p5051, p5253, p5455,p5657, p5859, p6061, p62;
    #endregion // PRIVATE_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        OnTrackingLost();
    }

    void Update()
    {
        // Pause the video if tracking is lost for more than two seconds
        if (mHasBeenFound && mLostTracking)
        {
            if (mSecondsSinceLost > 2.0f)
            {
                VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();
                if (video != null &&
                    video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    video.VideoPlayer.Pause();
                }

                mLostTracking = false;
            }

            mSecondsSinceLost += Time.deltaTime;
        }
    }

    #endregion //MONOBEHAVIOUR_METHODS


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
    #endregion //PUBLIC_METHODS


    #region PRIVATE_METHODS
    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();
       
        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }
        if (mTrackableBehaviour.TrackableName == "P8_9")
        {
            p89.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P10_11")
        {
            p1011.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P12-13")
        {
            p1213.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P14_15")
        {
            p1415.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P16_17")
        {
            p1617.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P18_19")
        {
            p1819.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P20_21")
        {
            p2021.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P23")
        {
            p2223.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P25")
        {
            p2425.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P27")
        {
            p2627.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P29")
        {
            p2829.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P31")
        {
            p3031.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P33")
        {
            p3233.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P35")
        {
            p3435.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "37")
        {
            p3637.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P39")
        {
            p3839.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P41")
        {
            p4041.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P43")
        {
            p4243.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P45")
        {
            p4445.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P47")
        {
            p4647.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P49")
        {
            p4849.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P51")
        {
            p5051.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P53")
        {
            p5253.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P55")
        {
            p5455.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P57")
        {
            p5657.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P59")
        {
            p5859.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P61")
        {
            p6061.SetActive(true);
        }
        if (mTrackableBehaviour.TrackableName == "P62")
        {
            p62.SetActive(true);
        }
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
       









































        // Optionally play the video automatically when the target is found

        VideoPlaybackBehaviour video = GetComponentInChildren<VideoPlaybackBehaviour>();
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
                    PauseOtherVideos(video);

                    // Play this video on texture where it left off
                    video.VideoPlayer.Play(false, video.VideoPlayer.GetCurrentPosition());
                }
                else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                {
                    // Pause other videos before playing this one
                    PauseOtherVideos(video);

                    // Play this video from the beginning
                    video.VideoPlayer.Play(false, 0);
                }
            }
        }

        mHasBeenFound = true;
        mLostTracking = false;
    }

    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }
        if (mTrackableBehaviour.TrackableName == "P8_9")
        {
            p89.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P10_11")
        {
            p1011.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P12-13")
        {
            p1213.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P14_15")
        {
            p1415.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P16_17")
        {
            p1617.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P18_19")
        {
            p1819.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P20_21")
        {
            p2021.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P23")
        {
            p2223.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P25")
        {
            p2425.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P27")
        {
            p2627.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P29")
        {
            p2829.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P31")
        {
            p3031.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P33")
        {
            p3233.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P35")
        {
            p3435.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "37")
        {
            p3637.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P39")
        {
            p3839.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P41")
        {
            p4041.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P43")
        {
            p4243.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P45")
        {
            p4445.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P47")
        {
            p4647.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P49")
        {
            p4849.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P51")
        {
            p5051.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P53")
        {
            p5253.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P55")
        {
            p5455.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P57")
        {
            p5657.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P59")
        {
            p5859.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P61")
        {
            p6061.SetActive(false);
        }
        if (mTrackableBehaviour.TrackableName == "P62")
        {
            p62.SetActive(false);
        }
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

        mLostTracking = true;
        mSecondsSinceLost = 0;
    }

    // Pause all videos except this one
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
    #endregion //PRIVATE_METHODS
}
