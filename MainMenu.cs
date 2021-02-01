using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

    // ���� ��ư
	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
        //Debug.Log("����!");
	}

    // �������� ��ư
	public void Quit ()
	{
		Debug.Log("������ ��....");
		Application.Quit();
        //Debug.Log("����!");
    }

}
