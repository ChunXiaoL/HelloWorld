using UnityEngine;
using System.Collections;

public class M_Attcak : MonoBehaviour {

	public GameObject Mtarget;

	private float speed = 10f;
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	void Move()
	{
		Vector3 delta = Mtarget.transform.position - transform.position;
		transform.LookAt (delta);
		transform.Translate (delta.normalized * speed * Time.deltaTime,Space.World);
	}
}
