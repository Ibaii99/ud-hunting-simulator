using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AS_Bullet : MonoBehaviour {
	
	public GameObject ParticleHit;
	public float ForceShoot = 1500;
	public int LifeTime = 3;
	public int HitForce = 3000;
	public int HitCountMax = 10;
	public bool IgnoreLocalPlayer = true;
	public bool DestroyWhenHit = true;
	public float BulletRaylength = 20;
	public float RunningRaylength = 40;
	public float FirstRaylength = 2000;
	
	
	public bool TargetLocked = false; //set to True. Bullet will running to a target that looking automatically
	
	private List<GameObject> objectHittedList = new List<GameObject>();
	private GameObject targetLookat;
	private Vector3 targetLookatOffset;
	private bool hited = false;
	private bool cameraLook;
	private int hitcount = 0;
	private int targetcount = 0;
	private AS_ActionPreset actionPreset;
	private float runningLength;
	private Vector3 pointShoot;
	private const int ignoreWalkThru = ~((1 << 29) | (1 << 2) | (1 << 27) | (1 << 4) | (1 << 26));
	
	
	private void addHitedObject(GameObject obj){
		objectHittedList.Add(obj);
	}
	private bool hittedObjectCheck(GameObject obj){
		for(int i=0;i<objectHittedList.Count;i++){
			if(obj == objectHittedList[i]){
				return true;
			}
		}
		return false;
	}
	
	public void HitTarget(Collider collision){
		// Using to be normal bullet without Action camera
	}

	public void  Start () {

		if(PlayerPrefs.GetInt("Gun") == 1)
		{
			ForceShoot = 300;
			HitForce = 200;
			FirstRaylength = 1000;

		}
		if(PlayerPrefs.GetInt("Gun") == 2)
		{
			ForceShoot = 400;
			HitForce = 250;
			FirstRaylength = 1200;
		}
		if(PlayerPrefs.GetInt("Gun") == 3)
		{
			ForceShoot = 500;
			HitForce = 300;
			FirstRaylength = 1400;
		}
		if(PlayerPrefs.GetInt("Gun") == 4)
		{
			ForceShoot = 800;
			HitForce = 350;
			FirstRaylength = 1500;
		}
		if(PlayerPrefs.GetInt("Gun") == 5)
		{
			ForceShoot = 1200;
			HitForce = 400;
			FirstRaylength = 1700;
		}
		if(PlayerPrefs.GetInt("Gun") == 6)
		{
			ForceShoot = 1500;
			HitForce = 500;
			FirstRaylength = 2000;
		}
		if(PlayerPrefs.GetInt("Gun") == 7)
		{
			ForceShoot = 2000;
			HitForce = 650;
			FirstRaylength = 2500;
		}


		// Get Action Preset from ActionCamera
		AS_ActionCamera actioncam = (AS_ActionCamera)GameObject.FindObjectOfType(typeof(AS_ActionCamera));
		if(actioncam!= null){
			actionPreset = actioncam.GetPresets();
			if(actionPreset != null){
				actionPreset.Initialize();
				actionPreset.Shoot(this.gameObject);
				BulletRaylength = actionPreset.BulletRaylength;
				RunningRaylength = actionPreset.RunningRaylength;
				FirstRaylength = actionPreset.FirstRaylength;
			}
		}
		
		
		if(!RayShoot(true)){
			FirstDetectTarget();
		}
		pointShoot = this.gameObject.transform.position;
		this.GetComponent<Rigidbody>().AddForce(this.transform.forward*ForceShoot);
		GameObject.Destroy(this.gameObject,LifeTime);
		this.GetComponent<Renderer>().enabled = false;	
	}
	void Update(){
		if(!hited){
			RayShoot(false);
			RunningDetectTarget();
			//if(rigidbody)
			//this.transform.forward = rigidbody.velocity.normalized;
		}
		if(actionPreset){
			if(hitcount >= targetcount){
				if(actionPreset.ActionCam!=null){
					actionPreset.ActionCam.ObjectFollowing = null;
				}
			}
		}
		if(Camera.main){
			if(Vector3.Distance(Camera.main.gameObject.transform.position,this.gameObject.transform.position)>5){
				this.GetComponent<Renderer>().enabled = true;	
			}
		}
	}
	
	void  FixedUpdate () {
		if(TargetLocked && GetComponent<Rigidbody>()){
			if(targetLookat!=null){
				this.transform.LookAt((targetLookat.transform.position+targetLookatOffset));
				float lateralSpeed = GetComponent<Rigidbody>().velocity.magnitude;
				this.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x,transform.forward.y,transform.forward.z) * lateralSpeed;
			}
		}
		
	}


	public bool RayShoot(bool first){
		bool res = false;
		RaycastHit[] hits;
		float ray = BulletRaylength * Time.timeScale;
		if(ray<0.5f)
		{
			ray = 0.5f;	
		}
   		hits = Physics.RaycastAll (transform.position, transform.forward, ray,ignoreWalkThru);
    	for (var i = 0;i < hits.Length; i++) 
		{
        	RaycastHit hit  = hits[i];
       	 	if (hit.collider)
			{				
        		if (hit.collider.tag != "Player" && hit.collider.tag!= this.gameObject.tag)
				{
					targetLookat = null;
					TargetLocked = false;
					if(!hittedObjectCheck(hit.collider.gameObject))
					{
						res = true;
						addHitedObject(hit.collider.gameObject);
						GameObject hitparticle = null;
						this.transform.position = hit.point;
 
   						if (hit.rigidbody)
						{
							hit.rigidbody.AddForceAtPosition(this.transform.forward * HitForce, hit.point);
						}
						if(hit.collider.gameObject.GetComponent<AS_BulletHiter>())
						{


							AS_BulletHiter bulletHit = hit.collider.gameObject.GetComponent<AS_BulletHiter>();
							bulletHit.PositionFocusOffset = (hit.point-hit.collider.gameObject.transform.position);
							if(bulletHit.ParticleHit)
							{
								hitparticle = (GameObject)Instantiate(bulletHit.ParticleHit,hit.point, hit.transform.rotation);
							}
							if(!first)
							{
								if(actionPreset)
								{
									actionPreset.TargetHited(hit.collider.gameObject,this.gameObject,bulletHit);
								}
							}
							else
							{
								cameraLook = true;	
							}
							bulletHit.OnHit(hit,this);
							runningLength = Vector3.Distance(pointShoot,this.gameObject.transform.position);
							//Added by shahid mehmood to destroy bullet after hitting enemy
							GameObject.Destroy(this.gameObject);
						}
						else
						{
							if(ParticleHit)
							{
								hitparticle = (GameObject)Instantiate(ParticleHit,hit.point, hit.transform.rotation);
   								GameObject.Destroy(hitparticle,5);
							}

							FPSInputController.firecount = FPSInputController.firecount + 1;

							Debug.Log("first called");
						}					
						if(hitparticle!=null)
						{
							if(hit.collider.GetComponent<Terrain>())
							{
								hitparticle.transform.forward = hit.normal;
							}
							else
							{
								hitparticle.transform.forward = this.transform.forward;
							}
							GameObject.Destroy(hitparticle,5);
//							Debug.Log("second called");
						}						
						if(DestroyWhenHit || hitcount>= HitCountMax || hit.collider.GetComponent<Terrain>()){
							hited = true;	
						}
						
						HitTarget(hit.collider);
					}
        		}
        	}
		}
   		if(hited)
		{
			if(actionPreset){
				actionPreset.OnBulletDestroy();
			}
   			GameObject.Destroy(this.gameObject);
   		}	
		return res;
	}

	public void RunningDetectTarget(){
		RaycastHit camerahits;
    	if (Physics.Raycast(transform.position, transform.forward,out camerahits, RunningRaylength,ignoreWalkThru)) {
      		RaycastHit hitcam = camerahits;
        	if (hitcam.collider){
				if (hitcam.collider.tag != "Player" && hitcam.collider.tag!= this.gameObject.tag){
        			if(!cameraLook){
        				cameraLook = true;
						if(hitcam.collider.GetComponent<AS_BulletHiter>()){
							AS_BulletHiter bulletHit = hitcam.collider.gameObject.GetComponent<AS_BulletHiter>();
							bulletHit.PositionFocusOffset = (hitcam.point-hitcam.collider.gameObject.transform.position);
							targetLookat = hitcam.collider.gameObject;
							targetLookatOffset = bulletHit.PositionFocusOffset;
							if(actionPreset){
								actionPreset.TargetDetected(hitcam.collider.gameObject,this.gameObject,bulletHit);
							}
						}
        			}
				}
        	}
    	}
	}
	
	/*public void FirstDetectTarget(){
		RaycastHit camerahits;
    	if (Physics.Raycast(transform.position, transform.forward,out camerahits, FirstRaylength,ignoreWalkThru)) {
      		RaycastHit hitcam = camerahits;
        	if (hitcam.collider){
				if (hitcam.collider.tag != "Player" && hitcam.collider.tag!= this.gameObject.tag){
					if(hitcam.collider.GetComponent<AS_BulletHiter>()){
						AS_BulletHiter bulletHit = hitcam.collider.gameObject.GetComponent<AS_BulletHiter>();
						bulletHit.PositionFocusOffset = (hitcam.point-hitcam.collider.gameObject.transform.position);
						targetLookat = hitcam.collider.gameObject;
						targetLookatOffset = bulletHit.PositionFocusOffset;
						if(actionPreset){
							actionPreset.FirstDetected(hitcam.collider.gameObject,this.gameObject,bulletHit);
						}
					}
				}
        	}
    	}
	}*/
	
	public void FirstDetectTarget(){
		RaycastHit[] camerahits;
		targetcount = 0;
    	camerahits = Physics.RaycastAll (transform.position, transform.forward, FirstRaylength,ignoreWalkThru);
    	for (var i = 0;i < camerahits.Length; i++) {
      		RaycastHit hitcam = camerahits[i];
        	if (hitcam.collider){
				if (hitcam.collider.tag != "Player" && hitcam.collider.tag!= this.gameObject.tag){

					if(hitcam.collider.GetComponent<AS_BulletHiter>()){
						targetcount+=1;
						AS_BulletHiter bulletHit = hitcam.collider.gameObject.GetComponent<AS_BulletHiter>();
						bulletHit.PositionFocusOffset = (hitcam.point-hitcam.collider.gameObject.transform.position);
						targetLookat = hitcam.collider.gameObject;
						targetLookatOffset = bulletHit.PositionFocusOffset;
						if(actionPreset){
							actionPreset.FirstDetected(hitcam.collider.gameObject,this.gameObject,bulletHit);
						}
					}
				}
        	}
    	}
	}

}
