using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError(""); //More than one BuildManager in scene!
            return;
		}
		instance = this;
	}

	public GameObject buildEffect;              // 터렛  구매시 효과
	public GameObject sellEffect;               // 터렛 판매시 효과

	private TurretBlueprint turretToBuild;
	private Node selectedNode;              // 선택 노드 액션

	public NodeUI nodeUI;                   // 노드 UI 집어넣기 위함.

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    // 셀렉트 노드 
	public void SelectNode (Node node)
	{
        // 노드 선택
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}
     
	public TurretBlueprint GetTurretToBuild ()
	{
		return turretToBuild;
	}

}
