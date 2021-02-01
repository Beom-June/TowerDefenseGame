using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    
    // ���� �׾����� ����ġ�� �����ϱ� ������.
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

        // 0�� �Ǹ� ���� �����ϱ� ������. ���⼭ 10�ʰ��� �ð��� �־���.
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;                 // ������ �־�� ������ ���۵� ��, ���� ��� ī��Ʈ �ٿ��� �ٽ� ��.
		}
		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;               // ���� ����� �Ѿ.
		Wave wave = waves[waveIndex];       // ������ ���� �ڵ�
		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);    //0.5f �ִ� �ͺ��� rate�ִ°��� �� �� ������.
		}

		waveIndex++;                        // ���� �Է½� ������

        if (waveIndex == waves.Length)
        {
            //Debug.Log("�� �������� �¸� �߽��ϴ�!");
            gameManager.WinLevel();
            this.enabled = false;
        }
	}

	void SpawnEnemy (GameObject enemy)          //enemy prefab ȣ��
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        // EnemiesAlive++;
	}
}
