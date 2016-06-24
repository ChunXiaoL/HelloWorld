using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour 
{

	#region 私有变量
	private bool IsMonster_small;

	private bool IsMonster_medium;

	private bool IsMonster_large;

	private bool IsMonster_huge;

	private GameObject fires;

	private Transform firePoint;

	private int Hp;

	public GameObject Target;

	public int HP
	{
		get{ return Hp;}
		private set{ Hp = value;}
	}

	#endregion

	#region Awake
	void Awake()
	{

		switch (this.gameObject.tag)
		{
		case "sMonster":
			Hp = 20;
			IsMonster_small = true;
			fires = Resources.Load<GameObject> ("MFire/SFires");
			break;
		case "mMonster":
			Hp = 30;
			IsMonster_medium = true;
			fires = Resources.Load<GameObject> ("MFire/MFires");
			break;
		case "lMonster":
			Hp = 40;
			IsMonster_large = true;
			fires = Resources.Load<GameObject> ("MFire/LFires");
			break;
		case "hMonster":
			Hp = 50;
			IsMonster_huge = true;
			fires = Resources.Load<GameObject> ("MFire/HFires");
			break;
			default:
				break;
		}
		firePoint = transform.FindChild ("firepoint");

	}
	#endregion

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		detectTarget ();
		Attack ();
		Hurt ();
		Dead ();
	}

	#region ——攻击——
	void Attack()
	{

		if (Target == null)
			return;
		if (fires == null) 
		{
			Debug.LogError ("Load Fires ERROR");
			return;
		}

		if(IsMonster_small)
		{
			GameObject go = GameObject.Instantiate (fires,firePoint.position,Quaternion.identity) as GameObject;
			M_Attcak script = go.AddComponent<M_Attcak> ();
			script.Mtarget = Target;
		}

		if(IsMonster_medium)
		{
			GameObject go = GameObject.Instantiate (fires,firePoint.position,Quaternion.identity) as GameObject;
			M_Attcak script = go.AddComponent<M_Attcak> ();
			script.Mtarget = Target;
		}

		if(IsMonster_large )
		{
			GameObject go = GameObject.Instantiate (fires,firePoint.position,Quaternion.identity) as GameObject;
			M_Attcak script = go.AddComponent<M_Attcak> ();
			script.Mtarget = Target;
		}

		if(IsMonster_huge)
		{
			GameObject go = GameObject.Instantiate (fires,firePoint.position,Quaternion.identity) as GameObject;
			M_Attcak script = go.AddComponent<M_Attcak> ();
			script.Mtarget = Target;
		}

	}//end Attack
		
	#endregion

	#region -------运动-------

	void MoveToTarget()
	{
		if(Target == null)
		{
			// walking or run or do something
			MoveWithoutTarget();
			return;
		}
		// @1  navigation

		// 

	}

	void MoveWithoutTarget()
	{
		// idle or walk or play or destroy something
	}

	#endregion


	#region ——受伤——
	void Hurt()
	{
		if (Target == null)
			return;

		if( Hp <= 0)
			return;
		
		if(IsMonster_small)
		{
			Hp -= Random.Range (2,6);
		}

		if(IsMonster_medium)
		{
			Hp -= Random.Range (3,7);
		}

		if(IsMonster_large )
		{
			Hp -= Random.Range (4,8);
		}

		if(IsMonster_huge)
		{
			Hp -= Random.Range (5,10);
		}

		MonsterController.Instance.BeHurt -= 5;

	}

	#endregion 

	#region ——死亡——

	void Dead()
	{
		if (Target == null)
			return;
		if (Hp > 0)
			return;

		MonsterController.Instance.DeadMonster.Push (this.gameObject);

		if(IsMonster_small)
		{
			Debug.LogWarning ("ENEMY_Small  dead");
			this.gameObject.SetActive(false);
		}

		if(IsMonster_medium)
		{
			Debug.LogWarning ("ENEMY_Small  dead");
			this.gameObject.SetActive(false);
		}

		if(IsMonster_large )
		{
			Debug.LogWarning ("ENEMY_Small  dead");
			this.gameObject.SetActive(false);
		}

		if(IsMonster_huge)
		{
			Debug.LogWarning ("ENEMY_Small  dead");
			this.gameObject.SetActive(false);
		}


	}

	#endregion

	#region 检测目标

	void detectTarget()
	{
		if (Target == null)
			return;
			
		// doing something to search the target using the TowerController
		int num = TowerController.Instance.Towerlist.Count;
		for (int i = 0; i < num; i++) 
		{
			float dis = Vector3.Distance(transform.position , TowerController.Instance.Towerlist[i].transform.position);
			if(dis < 15f)
			{
				Target = TowerController.Instance.Towerlist[i];
				break;
			}
		}
	}

	#endregion

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "TAttack")
		{
			Hurt ();
		}
	}
}