using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;

	public string menuSceneName = "MainMenu";

    // 씬 페이드를 위하여 추가
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

    // 재시도 버튼
	public void Retry ()
	{
		Toggle();
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 메뉴 버튼
	public void Menu ()
	{
		Toggle();
		sceneFader.FadeTo(menuSceneName);
        //Debug.Log("메뉴로");
	}

}
