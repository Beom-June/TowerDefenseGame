using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
	public Image img;                       // �̹��� �ҷ����� ����
	public AnimationCurve curve;            // �ִϸ��̼� curve�� �ֱ� ����

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
			img.color = new Color(0f, 0f, 0f, a);               // �̹��� �ҷ���, ������.
			yield return 0;
		}

        //down here
        //Load Scene
		SceneManager.LoadScene(scene);
	}
}
