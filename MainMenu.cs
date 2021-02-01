using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";

	public SceneFader sceneFader;

    // 시작 버튼
	public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
        //Debug.Log("시작!");
	}

    // 게임종료 버튼
	public void Quit ()
	{
		Debug.Log("나가는 중....");
		Application.Quit();
        //Debug.Log("종료!");
    }

}
