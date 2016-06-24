using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterController : MonoBehaviour 
{
	public static MonsterController Instance;

	private Transform MonsterHouse;

	private GameObject[] Monsters;

	public int BeHurt;

	public Stack DeadMonster = new Stack();

	public Dictionary<string , GameObject> MonsterDictionary  = new Dictionary<string, GameObject>();

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
	}

	// Use this for initialization
	void Start () 
	{
		BeHurt = 0;

		Monsters = Resources.LoadAll<GameObject> ("Monsters");

		MonsterHouse = GameObject.Find ("MosterHouse").transform;

		for (int i = 0; i < Monsters.Length; i++)
		{
			MonsterDictionary.Add (Monsters[i].name,Monsters[i]);
		}

		GenerateAllTypeMonster ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}



	/// <summary>
	/// Generates all type monster.
	/// </summary>
	void GenerateAllTypeMonster()
	{
		for (int i = 0; i < Monsters.Length; i++) 
		{
			GameObject go = Instantiate (Monsters[i], MonsterHouse.position+new Vector3(3*i,0,0), Quaternion.identity) as GameObject;
			go.transform.parent = MonsterHouse;
			go.name = Monsters [i].name;
		}
	}


	/// <summary>
	/// Generates the monster.
	/// </summary>
	/// <returns>The monster.</returns>
	IEnumerator GenerateMonster()
	{
		int index = 0;

		while(index < 5 )
		{
			GameObject go = Instantiate (MonsterDictionary["sMonster"], MonsterHouse.position, Quaternion.identity) as GameObject;
			go.transform.parent = MonsterHouse;
			go.name = MonsterDictionary ["sMonster"].name;
			index++;
			yield return new WaitForSeconds (1f);
		}

		while(index >= 5 && index < 9)
		{
			GameObject go =  Instantiate (MonsterDictionary["mMonster"], MonsterHouse.position, Quaternion.identity) as GameObject;
			go.transform.parent = MonsterHouse;
			go.name = MonsterDictionary ["mMonster"].name;
			index++;
			yield return new WaitForSeconds (1.5f);
		}

		while(index >= 9 && index < 12)
		{
			GameObject go = Instantiate (MonsterDictionary["lMonster"], MonsterHouse.position, Quaternion.identity) as GameObject;
			go.transform.parent = MonsterHouse;
			go.name = MonsterDictionary ["lMonster"].name;
			index++;
			yield return new WaitForSeconds (1.5f);
		}

		while(index >= 12 && index < 14)
		{
			GameObject go = Instantiate (MonsterDictionary["hMonster"], MonsterHouse.position, Quaternion.identity) as GameObject;
			go.transform.parent = MonsterHouse;
			go.name = MonsterDictionary ["hMonster"].name;
			index++;
			yield return new WaitForSeconds (1.5f);
		}

	}//end GenerateMonster()



	/// <summary>
	/// Wave this instance.
	/// </summary>
	IEnumerator Wave()
	{
		yield return new WaitForSeconds (15f);

		if(BeHurt > -100 && MonsterHouse.childCount == 0)
		{
			StartCoroutine (GenerateMonster());
		}
		yield return null;
	}
}
