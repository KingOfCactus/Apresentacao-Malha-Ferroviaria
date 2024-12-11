using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Experimental.Rendering;

[RequireComponent(typeof(VideoPlayer))]
public class SphericalVideoPlayer : MonoBehaviour
{
	[SerializeField] VideoClip video;
	RenderTexture texture;
	VideoPlayer player;

	void PlayVideo(VideoClip _video)
	{
		texture = new RenderTexture(4096, 2048, 24);
		texture.depthStencilFormat = GraphicsFormat.D16_UNorm;
		RenderSettings.skybox.mainTexture = texture;
		player.targetTexture = texture;
		player.clip = _video;
		player.Play();
		// StartCoroutine("PreparePlayer");


		// RenderTexture activeRenderTexture = RenderTexture.active;
        // RenderTexture.active = camera.targetTexture;
	    // camera.Render();
        // Texture2D image = new Texture2D(renderTexture.width, renderTexture.height);
        // image.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        // image.Apply();
        // RenderTexture.active = activeRenderTexture;
        // rawImage.texture = image;
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
		// PlayVideo(video)

	}

	void Update()
	{
		if (Input.GetKeyDown("space"))
		{
					PlayVideo(video);

		}
	}
}
