// Bullet marker. Using to adding into any objects that you want to have a Camera Action.
using UnityEngine;
using System.Collections;

public class AS_BulletHiter : MonoBehaviour {

	public Vector3 PositionFocusOffset;
	public GameObject ParticleHit;
	public GameObject RootObject;
	public AudioClip[] Sounds;
	

	void Awake () {
		if(!RootObject){
			RootObject = this.gameObject;	
		}
	}
	
	public virtual void OnHit(RaycastHit hit,AS_Bullet bullet)
	{

	}
	
	public void AddAudio(Vector3 point){
		GameObject sound = new GameObject("SoundHit");
		sound.AddComponent<AS_SoundOnHit>();
		GameObject soundObj = (GameObject)GameObject.Instantiate(sound,point,Quaternion.identity);
		soundObj.GetComponent<AS_SoundOnHit>().Sounds = Sounds;
		GameObject.Destroy(soundObj,3);

	}
}