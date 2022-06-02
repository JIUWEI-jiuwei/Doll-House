using UnityEngine.Video;
using UnityEngine;

///<summary>
///所有MP4的clip都存在这个脚本中，用同一个player进行播放，和音效一个用法
///</summary>
class VideoClips : MonoBehaviour
{
    public VideoClip[] videoClips;
    public VideoPlayer videoPlayer;

}
