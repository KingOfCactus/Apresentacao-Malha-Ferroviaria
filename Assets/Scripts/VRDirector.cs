using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VRDirector : MonoBehaviour
{
    [SerializeField] VideoClip[] stationClips;
    SphericalVideoPlayer vrPlayer;
    
    void Start() => vrPlayer = GetComponent<SphericalVideoPlayer>();
    public void PlayStationVideo(int index)
    {
        vrPlayer.Play360Video(stationClips[index]);
        StartCoroutine("ResetWhenVideoEnds");
    }
    
    IEnumerator ResetWhenVideoEnds()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitWhile(() => vrPlayer.isPlaying);
        // SceneUtils.ReloadScene();
    }
}
