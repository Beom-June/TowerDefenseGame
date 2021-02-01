using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public SceneFader fader;

	public Button[] levelButtons;       // 버튼 배열 생성

	void Start ()
	{
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);       // 1로 주어야 매시간, 플레이어가 새로운 게임이 가능.

		for (int i = 0; i < levelButtons.Length; i++)
		{
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
		}
	}

	public void Select (string levelName)
	{
		fader.FadeTo(levelName);
	}

}
