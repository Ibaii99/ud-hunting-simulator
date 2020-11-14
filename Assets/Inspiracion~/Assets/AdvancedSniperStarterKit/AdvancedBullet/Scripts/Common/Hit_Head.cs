using UnityEngine;
using System.Collections;
public class Hit_Head : AS_BulletHiter {
	public static bool hithead = false;
	public static bool headtext = false;	

	public string headname = "";
	public bool headshoot = false;
	void Start()
	{
		headshoot = false;
		hithead = false;
		headtext = false;
	}
	public override void OnHit (RaycastHit hit,AS_Bullet bullet)
	{
		headshoot = true;
		headname = hit.collider.gameObject.name;


		AddAudio(hit.point);
		base.OnHit (hit,bullet);
	}
}
