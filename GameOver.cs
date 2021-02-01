using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";

    // �����̵带 ���Ͽ� �߰�.
	public SceneFader sceneFader;


    // ��õ�
	public void Retry ()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
        //Debug.Log("�޴��� �� ��.");
	}

}
