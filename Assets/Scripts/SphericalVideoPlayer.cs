using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer), typeof(MeshRenderer))]
public class SphericalVideoPlayer : MonoBehaviour
{
	/* For some unknown reason, redmi devices tend to render a black screen if the render texture
	   isn't present in the UI in some way. */
	[SerializeField] RawImage weirdXiaomiWorkaround;
	
	VideoPlayer player;
	Material mat;

	void Start()
	{
		player = GetComponent<VideoPlayer>();
		mat = GetComponent<MeshRenderer>().material;
		player.renderMode = VideoRenderMode.RenderTexture;
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

		player.targetTexture = texture;
		player.clip = video;

		player.targetTexture = texture;
		weirdXiaomiWorkaround.texture = texture;
		mat.mainTexture = weirdXiaomiWorkaround.texture;

		if (prepareBeforePlaying)
			StartCoroutine("PrepareAndPlay");
		else
			player.Play();
	}

	public void Play360Video(bool prepareBeforePlaying = false)
	{
		if (player.clip == null)
		{
			Debug.LogError($"[{transform.name}] No videoclip provided.");
			return;
		}

		var texture = new RenderTexture((int)player.clip.width, (int)player.clip.height, 24);
		texture.depthStencilFormat = GraphicsFormat.D16_UNorm;

		player.targetTexture = texture;
		weirdXiaomiWorkaround.texture = texture;
		mat.mainTexture = weirdXiaomiWorkaround.texture;


		if (prepareBeforePlaying)
			StartCoroutine("PrepareAndPlay");
		else
			player.Play();
	}

}
