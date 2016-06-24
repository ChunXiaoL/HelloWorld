using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour 
{

	#region 私有变量

	private bool IsSTower;

	private bool IsATower;

	private bool CanAttack;

	private GameObject S_attack;

	private GameObject A_attack;

	private GameObject Target;

	private Material Mtp1;
	private Material Mtp2;

	private bool CanChangeMaterial;

	private GameObject a1;
	#endregion



	public int Hp =100;

	public Transform enemy;


	#region Awake
	void Awake()
	{
		if(this.gameObject.tag == "STower")
		{
			IsSTower = true;
			IsATower = false;
		}
		else if(this.gameObject.tag == "ATower")
		{
			IsATower = true;
			IsSTower = false;
		}

		CanAttack = false;

		Mtp1 = Resources.Load<Material> ("p1");
		Mtp2 = Resources.Load<Material>("p2");
		a1 = Resources.Load<GameObject>("A1");
	}
	#endregion

	#region Start
	// Use this for initialization
	void Start () 
	{

		enemy = GameObject.Find ("MosterHouse").transform;

		if(IsSTower)
		{
			S_attack = Resources.Load<GameObject>("STAttack");
			Debug.Log ("减速");
		}
		if(IsATower)
		{
			A_attack = Resources.Load<GameObject>("ATAttack");
			Debug.Log ("攻击");
		}
		this.gameObject.GetComponent<MeshRenderer> ().material = Mtp1;
	}

	#endregion
	
	#region Update
	// Update is called once per frame
	void Update () 
	{
		if(CanAttack)
		{
			Attack ();
		}

		AttackDetect(enemy);

		BeDestroyed ();

		if(CanChangeMaterial)
		{
			this.gameObject.GetComponent<MeshRenderer> ().material = Mtp2;
			CanChangeMaterial = false;
		}
	}

	#endregion

	#region ——攻击——
	void Attack()
	{
		if(IsSTower)
		{
//			Instantiate (S_attack);
			Debug.Log ("Slow");
		}
		if(IsATower)
		{
			GameObject aa = Instantiate (a1,transform.position,Quaternion.identity) as GameObject;

			aa.GetComponent<T_Attack>().Ttarget= Target;

			Debug.Log ("Attack");
		}
	}

	#endregion

	#region 检测目标

	void AttackDetect(Transform enemy)
	{


		for (int i = 0; i < enemy.childCount; i++) 
		{
			float Dis = Vector3.Distance(transform.position, enemy.GetChild (i).position);

			if(Dis < 20f)
			{
				Target = enemy.GetChild (i).gameObject;
				CanAttack = true;
				break;
			}
		}
	}

	#endregion

	#region 受损

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "MonserA")
		{
			Hp -= Random.Range(3,10);
			CanChangeMaterial= true;
			//替换材质
			Debug.Log (other.gameObject.tag);
		}
		Debug.Log (other.gameObject.tag);
	}

	#endregion

	#region 被摧毁/毁掉

	void BeDestroyed()
	{
		if(Hp <= 0)
		{
			//播放动画
			//动画播放完之后，destroy
//			if()
//			{
				Destroy(this.gameObject);
//			}

			TowerController.Instance.Towerlist.Remove (this.gameObject);
		}
	}

	#endregion


}
