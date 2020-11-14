using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Status : MonoBehaviour {

	public GameObject[] deadbody;
	public string deadbodyRootName = "Root";
	public AudioClip[] hitsound;
	public int hp = 100;
	private Vector3 velositydamage;
	//private int score;
	//public int value ;

	public GameObject loadingText = null;

	void Awake()
	{
		//score = 0;
	}
	public void PlayGame ()
	{
		Application.LoadLevel ("Game");
	}

	public void ApplyDamage (int damage,Vector3 velosity) {
		/*if(hp<=0){
			return;
		}*/
		hp -= damage;
		velositydamage = velosity;
 		if(hp<=0){
 			Dead(Random.Range(0,deadbody.Length));
 		}
	}
	public void ApplyDamage (int damage,Vector3 velosity,int deadIndex) {

		/*if(hp<=0){
			return;
		}*/
		hp -= damage;
		velositydamage = velosity;
 		if(hp<=0){
 			Dead(deadIndex);
 		}
	}

	// ** Important part for Ragdoll replacement
	private AS_ActionCamera actioncam;
	public void Dead(int index){

		if(deadbody.Length>0 && index>=0 && index<deadbody.Length){

			// this Object has removed by Dead and replaced with Ragdoll. the ObjectTarget will null and ActionCamera will stop following and looking.
			// so we have to update ObjectTarget to this Ragdoll replacement. then ActionCamera to continue fucusing on it.
			GameObject ragdoll = (GameObject)Instantiate(deadbody[index],this.transform.position,this.transform.rotation);
			actioncam = (AS_ActionCamera)FindObjectOfType(typeof(AS_ActionCamera));
			// Focus on dead object replaced
			actioncam.ObjectTarget = ragdoll.gameObject;
			// copy all of transforms to dead object replaced
			CopyTransformsRecurse(this.transform, ragdoll);
			// destroy dead object replaced after 5 sec

			GUI_Score.score = GUI_Score.score + 1;

			Destroy(ragdoll,5);
			// destroy this game object.
			Destroy(this.gameObject);
		}
	}
	//fawad gui

	void OnGUI(){
	}

	// Copy all transform to Ragdoll object
	public void CopyTransformsRecurse (Transform src,GameObject dst) {

		dst.transform.position = src.position;
		dst.transform.rotation = src.rotation;
		//dst.transform.localScale = src.localScale;
		if(dst.GetComponent<Rigidbody>() && src.GetComponent<Rigidbody>()){
			dst.GetComponent<Rigidbody>().velocity = src.GetComponent<Rigidbody>().velocity;
		}
		
		// Have to looking for root of Ragdoll and update it to ObjectTarget in ActionCamera 
		if(actioncam.ObjectTargetRoot == this.gameObject){
			if(dst.name == deadbodyRootName){
				// Then ActionCamera will continue looking at this object instead.
				actioncam.ObjectTarget = dst.gameObject;
			}
		}
		if(dst.name == deadbodyRootName){
			if(dst.GetComponent<Rigidbody>()){
				dst.GetComponent<Rigidbody>().AddForce(velositydamage,ForceMode.Impulse);
			}
		}

		foreach (Transform child in dst.transform) {
			var curSrc = src.Find(child.name);
			if (curSrc){
				CopyTransformsRecurse(curSrc, child.gameObject);
			}
		}
	}
}