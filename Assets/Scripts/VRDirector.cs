using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

[RequireComponent(typeof(SphericalVideoPlayer))]
public class VRDirector : MonoBehaviour
{  
    [System.Serializable]
    public struct StationPlayback
    {
        public VideoClip clip;
        public Vector3 sphereRotation;
    }

    [SerializeField] StationPlayback[] stations;
    SphericalVideoPlayer vrPlayer;
    
    void Start() => vrPlayer = GetComponent<SphericalVideoPlayer>();

    public void PlayStationVideo(int index)
    {
        var playback = stations[index];
        vrPlayer.Play360Video(playback.clip);
        vrPlayer.transform.localEulerAngles = playback.sphereRotation;
        StartCoroutine(ResetWhenVideoEnds((float)playback.clip.length));
    }
    
    IEnumerator ResetWhenVideoEnds(float time)
    {
        yield return new WaitForSeconds(time + 3f);
        SceneUtils.ReloadScene();
    }
}
