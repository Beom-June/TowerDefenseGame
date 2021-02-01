using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

	public Text livesText;

	// 업데이트는 프레임당 한 번 호출.
	void Update () {
		livesText.text = PlayerStats.Lives.ToString() + " LIVES";
	}
}
