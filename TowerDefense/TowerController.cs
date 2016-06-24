using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : MonoBehaviour 
{
	public  int Score = 0;

	private bool IsCanBuild = false;

	public Transform Tp1;

	public Transform Tp2;

	public static TowerController Instance = null;


	public List<GameObject> Towerlist = new List<GameObject>();

	private GameObject pp1;
	private GameObject pp2;




	enum TowerType
	{
		STower,
		ATower
	}

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}

		Tp1 = GameObject.Find ("p1").transform;
		Tp2 = GameObject.Find ("p2").transform;
		pp1 = Resources.Load<GameObject>("Capsule");
		pp2 = Resources.Load<GameObject>("Sphere");

	}
	// Use this for initialization
	void Start () 
	{
		//一开始先生成两座塔
		BuildTower(TowerType.ATower,Tp1);

		BuildTower (TowerType.STower,Tp2);

		//将塔放入列表
		Towerlist.Add (Tp1.GetChild (0).gameObject);
		Towerlist.Add (Tp2.GetChild (0).gameObject);

//		Debug.Log (Towerlist[0].name);
//		Debug.Log (Towerlist[1].name);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Score >= 100)
		{
			IsCanBuild = true;
		}
	
		if(Score < 100)
		{
			IsCanBuild = false;
		}
		if(Input.GetKeyDown(KeyCode.B)&& IsCanBuild)
		{
			BuildTower(TowerType.ATower,Tp1);
		}
	}

	void BuildTower(TowerType type,Transform parent)
	{
		if(parent.childCount == 0 && type == TowerType.STower)
		{
//			Instantiate();
			GameObject go = GameObject.Instantiate(pp1,parent.position,Quaternion.identity) as GameObject;
			go.transform.parent = parent;
			Towerlist.Add (go);
			Score -= 100;
		}
		if(parent.childCount == 0 && type == TowerType.ATower)
		{
//			Instantiate();
			GameObject go = GameObject.Instantiate(pp2,parent.position ,Quaternion.identity) as GameObject;
			go.transform.parent = parent;
			Towerlist.Add (go);
			Score -= 100;
		}
	}


}
