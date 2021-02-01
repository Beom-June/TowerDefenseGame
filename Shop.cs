using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamer;

	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

    // 기본 $100 터렛 구매
	public void SelectStandardTurret ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

    // $250 미사일 터렛 구매
	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurretToBuild(missileLauncher);
	}

    // $350 레이저 터렛 구매
	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laserBeamer);
	}
}
