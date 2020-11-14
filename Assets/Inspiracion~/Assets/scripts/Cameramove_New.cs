using UnityEngine;
using System.Collections;
public class Cameramove_New : MonoBehaviour {
	public static Transform target;
	float distance = 6.0f;
	private float x = 0.0f;
	private float y = 0.0f;
//	private bool AutoRotate = true;
	public float xSpeed = 250.0f;
	void Start()
	{
//		AutoRotate = true;
		target = GameObject.FindGameObjectWithTag("0").transform;
	}
	void Update()
	{
//		if(Input.GetMouseButton(0))
//		{
//			AutoRotate = false;
//		}
//		else
//		{
//			AutoRotate = true;
//		}
//		if (AutoRotate == false)
//		{
//			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
//			var rotation = Quaternion.Euler(42, x, 0);
//			var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;			
//			transform.rotation = rotation;
//			transform.position = position;			
//		}
//		else
//		{
			x += 0.3f;
			var rotation = Quaternion.Euler(42,x, 0);
			var position = rotation *  new Vector3(0.0f, 0.0f, -distance) + target.position;			        
			transform.rotation = rotation;
			transform.position = position;
//		}		
	}
}
