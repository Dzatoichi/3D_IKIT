using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string videoFileName = "1_VID_DIRICTOR_IKIT_IOC.mp4";

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.Play();
    }
}