using UnityEngine;
using System.Collections;

[System.Serializable]
public class TurretBlueprint {

	public GameObject prefab;
	public int cost;

    // 업그레이드
	public GameObject upgradedPrefab;
	public int upgradeCost;

    // 판매 금액 회수.
	public int GetSellAmount ()
	{
		return cost / 2;
	}
}
