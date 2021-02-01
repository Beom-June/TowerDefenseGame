using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public string menuSceneName = "MainMenu";

    // �� ���̵带 ���Ͽ� �߰�
	public SceneFader sceneFader;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
	}

	public void Toggle ()
	{
		ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		}

        else
		{
			Time.timeScale = 1f;
		}
	}

    // ��õ� ��ư
	public void Retry ()
	{
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // �޴� ��ư
	public void Menu ()
	{
		Toggle();
		sceneFader.FadeTo(menuSceneName);
        //Debug.Log("�޴���");
	}

}
