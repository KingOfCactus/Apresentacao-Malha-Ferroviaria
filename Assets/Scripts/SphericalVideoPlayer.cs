using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Experimental.Rendering;

[RequireComponent(typeof(VideoPlayer), typeof(MeshRenderer))]
public class SphericalVideoPlayer : MonoBehaviour
{
	VideoPlayer player;
	Material mat;

	void Start()
	{
		player = GetComponent<VideoPlayer>();
		mat = GetComponent<MeshRenderer>().material;
	}

	IEnumerator PrepareAndPlay()
	{
		player.Prepare();
		yield return new WaitUntil(() => player.isPrepared);
		player.Play();
	}

	public void Play360Video(VideoClip video, bool prepareBeforePlaying = false)
	{
		var texture = new RenderTexture((int)video.width, (int)video.height, 24);
		texture.depthStencilFormat = GraphicsFormat.D16_UNorm;
		mat.mainTexture = texture;

		player.targetTexture = texture;
		player.clip = video;

		if (prepareBeforePlaying)
			StartCoroutine("PrepareAndPlay");
		else
			player.Play();
	}

	public void Play360Video(bool prepareBeforePlaying = false)
	{
		if (player.clip.Equals(null))
		{
			Debug.LogError($"[{transform.name}] No videoclip provided.");
			return;
		}

		RenderTexture texture = new RenderTexture(4096, 2048, 24);
		texture.depthStencilFormat = GraphicsFormat.D16_UNorm;
		player.targetTexture = texture;
		mat.mainTexture = texture;

		if (prepareBeforePlaying)
			StartCoroutine("PrepareAndPlay");
		else
			player.Play();
	}

}
