using UnityEngine;

[System.Serializable]                   // 스크립트 직렬화를 하기 위하여 넣음.
public class Wave {

	public GameObject enemy;            // 적 스폰을 위한 코드
	public int count;
	public float rate;
}
