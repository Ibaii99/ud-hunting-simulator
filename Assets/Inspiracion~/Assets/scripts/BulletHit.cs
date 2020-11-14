using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {
	public static bool hitbullet = false;
	// Use this for initialization
	void Start () {
		hitbullet = false;
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.transform.tag == "Bullet")
		{
			hitbullet = true;
			Destroy(col.gameObject);
		}
	}
}
