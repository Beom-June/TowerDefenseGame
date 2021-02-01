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

	// ������Ʈ�� �������� �ѹ� ���� ��.
    // Live�� 0���� ���� �׾����� ����.
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
        //Debug.Log("�� �������� �¸� �߽��ϴ�!");
        //PlayerPrefs.SetInt("levelReached", levelToUnlock);
        //sceneFader.FadeTo(nextlevel);                       // ���� ������
        GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

}
