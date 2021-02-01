using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    
    // 적이 죽었을때 가중치를 변경하기 위함임.
	public static int EnemiesAlive = 0;
	public Wave[] waves;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	public Text waveCountdownText;
	public GameManager gameManager;
	private int waveIndex = 0;

	void Update ()
	{

		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

        // 0이 되면 적이 등장하기 시작함. 여기서 10초간의 시간이 주어짐.
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;                 // 리턴을 넣어야 게임이 시작된 후, 적을 잡고 카운트 다운이 다시 됨.
		}
		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;               // 다음 라운드로 넘어감.
		Wave wave = waves[waveIndex];       // 생성을 위한 코드
		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);    //0.5f 넣는 것보다 rate넣는것이 좀 더 깨끗함.
		}

		waveIndex++;                        // 위에 입력시 오류남

        if (waveIndex == waves.Length)
        {
            //Debug.Log("이 레벨에서 승리 했습니다!");
            gameManager.WinLevel();
            this.enabled = false;
        }
	}

	void SpawnEnemy (GameObject enemy)          //enemy prefab 호출
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        // EnemiesAlive++;
	}
}
