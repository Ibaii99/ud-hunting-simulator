using UnityEngine;
using System.Collections;

public class AS_ActionPreset : MonoBehaviour {
	[HideInInspector]
	public AS_ActionCamera ActionCam;
	public float CameraRaylength = 40;
	public float BulletRaylength = 20;
	public float RunningRaylength = 40;
	public float FirstRaylength = 2000;
	
	
	public void Start(){
		Initialize();
	}
	public void Initialize()
    {
		ActionCam = (AS_ActionCamera)FindObjectOfType(typeof(AS_ActionCamera));
	}
	// When shooting.
	public virtual void Shoot(GameObject bullet)
    {

    }
	// When bullet start and detected a target on the way.
	public virtual void FirstDetected(GameObject target,GameObject bullet,AS_BulletHiter hiter)
    {
		if(!ActionCam){
			return;	
		}
		ActionCam.Detected = true;
		ActionCam.ObjectTargetRoot = hiter.RootObject;
    }
	// When bullet flying and detected a target on the way.
	public virtual void TargetDetected(GameObject target,GameObject bullet,AS_BulletHiter hiter)
    {
		if(!ActionCam){
			return;	
		}
		ActionCam.Detected = true;
		ActionCam.ObjectTargetRoot = hiter.RootObject;
    }
	// When bullet hit target
	public virtual void TargetHited(GameObject target,GameObject bullet,AS_BulletHiter hiter)
    {
		if(!ActionCam){
			return;	
		}
		ActionCam.HitTarget = true;
		ActionCam.ObjectTargetRoot = hiter.RootObject;
		
    }
	
	//When bullet has been removed
	public virtual void OnBulletDestroy()
    {
		if(!ActionCam){
			return;	
		}
		if(!ActionCam.HitTarget){
			ActionCam.TimeSet(1);
		}
		if(ActionCam.Detected){
			if(!ActionCam.HitTarget){
				ActionCam.ClearTarget();
			}
		}
	
    }
	
	
	// Checking prevent the Camera stay down under Terrain
	public RaycastHit PositionOnTerrain(Vector3 position){
		RaycastHit res = new RaycastHit();
		res.point = position;
		if(GameObject.FindObjectOfType(typeof(Terrain))){
			Terrain terrain = (Terrain)GameObject.FindObjectOfType(typeof(Terrain));
			if(terrain){
				RaycastHit hit;
        		if (Physics.Raycast(position, -Vector3.up,out hit)) {
            		res = hit;
        		}
			}else{
				Debug.Log("No Terrain");	
			}	
		}
		return res;
	}
	public Vector3 TerrainFloor(Vector3 position){
		Vector3 res = position;
		RaycastHit positionSpawn = PositionOnTerrain(position + (Vector3.up * 100));
		if(positionSpawn.point.y > position.y){
			res = new Vector3(position.x,positionSpawn.point.y+1,position.z);
		}
		return res;
	}
	
}
