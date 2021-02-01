using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

    //public string nextlevel = "Level02";
    //public int levelToUnlock = 2;

   //public SceneFader sceneFader;

	void Start ()
	{
		GameIsOver = false;
	}

	// 업데이트당 프레임은 한번 실행 됨.
    // Live가 0보다 적어 죽었을때 실행.
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel ()
	{
        //Debug.Log("이 레벨에서 승리 했습니다!");
        //PlayerPrefs.SetInt("levelReached", levelToUnlock);
        //sceneFader.FadeTo(nextlevel);                       // 다음 레벨로
        GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
