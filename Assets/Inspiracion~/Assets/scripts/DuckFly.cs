using UnityEngine;
using System.Collections;

public class DuckFly : MonoBehaviour {
	public float rotationSpeed = 3.0f;
	public float flyspeed = 8.0f;
	public Transform one;
	public Transform two;
	public Transform three;
	public Transform four;
	public Transform target;
	private float distance ;

//	private string transformname;

	public bool flystate = false;
	public static bool fire = false;

	void Start () 
	{
		flystate = false;
		fire = false;
		target = one;	
		//transformname = transform.name;
	}
	void Update () 
	{
		if(fire)
		{
			StartCoroutine(wait());
		}
		if(flystate)
		{
			transform.GetComponent<Animation>().Play ("fly");
			var lookDir = target.position - transform.position;
			//lookDir.y = 0; // zero the height difference 
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
			transform.position += transform.forward * flyspeed* Time.deltaTime;

			if((transform.position - one.position).magnitude < 2)
			{
				target = two;
			}
			if((transform.position - two.position).magnitude < 2)
			{
				target = three;
			}
			if((transform.position - three.position).magnitude < 2)
			{
				target = four;
			}if((transform.position - four.position).magnitude < 2)
			{
				target = one;
			}
		}
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds (1.0f);
		flystate = true;
	}
}
