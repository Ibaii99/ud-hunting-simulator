using UnityEngine;
using System.Collections;

public class Bulletdestroy : MonoBehaviour {
	void OnCollisionEnter(Collision col)
	{
		if(col.transform.tag == "Bullet")
		{
			Destroy(col.gameObject);
		}
	}
}
