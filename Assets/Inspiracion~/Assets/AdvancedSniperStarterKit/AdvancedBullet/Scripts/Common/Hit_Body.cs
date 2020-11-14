using UnityEngine;
using System.Collections;
public class Hit_Body : AS_BulletHiter {
	public static bool bodytext = false;
	public static string name = "";
	public static bool hitbody = false;

	public bool bodyshoot = false;
	public string bodyname = "";

	void Start()
	{
		bodyname = "";
		bodyshoot = false;
		name = "";
		bodytext = false;
		hitbody = false;
	}
	public override void OnHit (RaycastHit hit,AS_Bullet bullet)
	{
		hitbody = true;
		bodyshoot = true;
		name = hit.collider.gameObject.name;
		bodyname = hit.collider.gameObject.name;

		AddAudio(hit.point);
		base.OnHit (hit,bullet);
	}
}