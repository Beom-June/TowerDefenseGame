using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;                 // 시작 체력
	private float health;

	public int worth = 50;                          // 적을 잡았을때 얻는 돈.

	public GameObject deathEffect;                  // 몹이 죽었을때 효과

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth;
	}

    // 적에게 데미지를 주었을때 계산.
	public void TakeDamage (float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

    // 터렛한테서 맞을때 속도 감소
	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.Money += worth;                                                 // 돈 증가.

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);      // 죽었을때 효과 입력.
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;         // 적이 죽었을때 호출. 적 감소.

		Destroy(gameObject);
	}

}
