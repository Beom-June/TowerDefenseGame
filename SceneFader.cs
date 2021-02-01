using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
	public Image img;                       // 이미지 불러오기 위함
	public AnimationCurve curve;            // 애니메이션 curve를 넣기 위함

	void Start ()
	{
		StartCoroutine(FadeIn());
	}

	public void FadeTo (string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn ()
	{
		float t = 1f;

		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color (0f, 0f, 0f, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut(string scene)
	{
		float t = 0f;                   // t = time value

		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, a);               // 이미지 불러옴, 검정색.
			yield return 0;
		}

        //down here
        //Load Scene
		SceneManager.LoadScene(scene);
	}
}
