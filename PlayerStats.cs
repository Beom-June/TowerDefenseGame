using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 10;

	public static int Rounds;


    // 게임 시작
    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
}
