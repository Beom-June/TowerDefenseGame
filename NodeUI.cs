using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;            // 업그레이드 버튼

	public Text sellAmount;

	private Node target;


    // 타겟 세팅
	public void SetTarget (Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded)
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		}

        else                                           //업그레이드 완료
		{
			upgradeCost.text = "업그레이드 완료";
			upgradeButton.interactable = false;
		}

		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

		ui.SetActive(true);
	}

    // 다른 곳 클릭시 노드 UI 없애기 위함.
	public void Hide ()
	{
		ui.SetActive(false);
	}

	public void Upgrade ()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell ()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}

}
