using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";

    // 씬페이드를 위하여 추가.
	public SceneFader sceneFader;


    // 재시도
	public void Retry ()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
        //Debug.Log("메뉴로 갈 것.");
	}

}
