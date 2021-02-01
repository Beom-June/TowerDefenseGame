using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    //]Header("Optional")]
	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
    }

	public Vector3 GetBuildPosition ()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

    // 터렛 짓기.
	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("터렛을 짓는데 돈이 부족합니다!");
			return;
		}

        // 터렛 지을시 돈 감소
		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("터렛이 지어졌습니다!!");
	}

    // 터렛 업그레이드.
	public void UpgradeTurret ()
	{
        // 돈 부족 할 경우 호출
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("터렛을 업그레이드 하는데 돈이 부족 합니다!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//오래된 터렛 버리는 코드.
		Destroy(turret);

		//새로운것 설치.
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

        // 업그레이드 되면 코드 실행.
		isUpgraded = true;

		Debug.Log("터렛이 업그레이드 되었습니다!");
	}

    //터렛 판매 계산.
	public void SellTurret ()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

        // 판매 버튼 누른 후 터렛은 파괴.
		Destroy(turret);
		turretBlueprint = null;
	}

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		} else
		{
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

}
