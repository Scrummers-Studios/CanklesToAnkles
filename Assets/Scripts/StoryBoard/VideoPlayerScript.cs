using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button myButton;

    void Start()
    {
        // Disable the button initially
        myButton.gameObject.SetActive(false);

        // Set up a callback for when the video is finished
        videoPlayer.loopPointReached += VideoFinished;
    }

    void VideoFinished(VideoPlayer vp)
    {
        // Video has finished playing, enable the button
        myButton.gameObject.SetActive(true);
    }

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        // Add your code here to handle the button click event
    }
}
