using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(VideoPlayer))]
public class SphericalVideoPlayer : MonoBehaviour
{
	[SerializeField] VideoClip video;
	RenderTexture texture;
	VideoPlayer player;

	void PlayVideo(VideoClip _video)
	{
		texture = new RenderTexture(4096, 2048, 24);
		RenderSettings.skybox.mainTexture = texture;
		player.targetTexture = texture;
		player.clip = _video;
		player.Play();
		// StartCoroutine("PreparePlayer");
	}

	IEnumerator PreparePlayer()
	{
		player.Prepare();
		yield return new WaitUntil(() => player.isPrepared);
		player.Play();
	}

	void Awake()
	{
		player = GetComponent<VideoPlayer>();
		PlayVideo(video);

	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
					PlayVideo(video);

		}
	}
}
