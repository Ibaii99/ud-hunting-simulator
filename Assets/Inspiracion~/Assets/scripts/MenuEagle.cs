using UnityEngine;
using System.Collections;
public class MenuEagle : MonoBehaviour 
{
	private float distance;
	private Transform Myself;
	public float moveSpeed = 6;	
	private float rotationSpeed = 3.0f;

	public Transform point1;
	public Transform point2;
	public Transform point3;

	private float number = 0;	

	void Start () 
	{	
		number = 1.0f;
		Myself = this.transform;
	}	
	void Update ()
	{	
//		if (number == 1.0f) 
//		{
//			distance = (point1.position - Myself.position).magnitude;
//			if (distance > 3) {
//				Myself.animation.Play ("flyNormal");
//				var lookDir = point1.position - Myself.position;
//				//lookDir.y = 0; // zero the height difference 
//				Myself.rotation = Quaternion.Slerp (Myself.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
//				Myself.position += Myself.forward * moveSpeed * Time.deltaTime;	
//			}
//			if(distance < 3)
//			{
//				number = 2.0f;	
//			}
//		}
//		if (number == 2.0f) 
//		{
//			distance = (point2.position - Myself.position).magnitude;
//			if (distance > 3) {
//				Myself.animation.Play ("flyNormal");
//				var lookDir = point2.position - Myself.position;
//				//lookDir.y = 0; // zero the height difference 
//				Myself.rotation = Quaternion.Slerp (Myself.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
//				Myself.position += Myself.forward * moveSpeed * Time.deltaTime;
//			}
//			if(distance < 3)
//			{
//				number = 3.0f;	
//			}
//		}
//		if (number == 3.0f) 
//		{			
//			distance = (point3.position - Myself.position).magnitude;
//			if (distance > 3) {
//				Myself.animation.Play ("flyNormal");
//				var lookDir = point3.position - Myself.position;
//				//lookDir.y = 0; // zero the height difference 
//				Myself.rotation = Quaternion.Slerp (Myself.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
//				Myself.position += Myself.forward * moveSpeed * Time.deltaTime;	
//			}
//			if(distance < 3)
//			{
//				number = 1.0f;	
//			}
//		}	
	}	
}