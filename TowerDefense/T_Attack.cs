using UnityEngine;
using System.Collections;

public class T_Attack : MonoBehaviour
{
	public GameObject Ttarget;


	private float speed = 10f;

	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	void Move()
	{
		Vector3 delta = Ttarget.transform.position - transform.position;
		transform.LookAt (delta);
		transform.Translate (delta.normalized * speed * Time.deltaTime,Space.World);
	}
}
