using UnityEngine;
using System.Collections;
public class MenuDuck : MonoBehaviour 
{
	private Transform Myself;
	public float Speed = 3;
	public Vector3 targetPosition;
	private GameObject player;
	public Transform point1;
	public Transform point2;
	public Transform point3;
	
	private int path;
	
	void Start () 
	{	
		Myself = this.transform;		
		path=0;		
		Myself.GetComponent<Animation>().CrossFade("fly", 0.1f);		
		targetPosition = point3.position;
	}
	
	void Update ()
	{	
		Myself.GetComponent<Animation>().CrossFade("fly", 0.1f);				
		if(this.transform.position == targetPosition && path == 0)
		{
			path = 1;
			targetPosition = point1.position;
		}				
		if(this.transform.position == targetPosition && path == 1)
		{
			path = 2;
			targetPosition = point2.position;
		}				
		if(this.transform.position == targetPosition && path == 2)
		{
			path = 0;
			targetPosition = point3.position;
		}		
		targetPosition.y = transform.position.y;                        
		transform.LookAt(targetPosition);
		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);				
	}	
}