using UnityEngine;
using System.Collections;

public class AP_HitSlowPreset : AS_ActionPreset {
	bool locked = false;
	public override void FirstDetected (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}
		if(!ActionCam.InAction){
			ActionCam.ObjectTarget = target;
		}
		base.FirstDetected (target, bullet,hiter);
	}
	public override void Shoot (GameObject bullet)
	{
		if(!ActionCam){
			return;	
		}
		locked = false;
		base.Shoot (bullet);
	}
	public override void TargetDetected (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}
		
		if(!ActionCam.InAction){
			ActionCam.ObjectTarget = target;
			ActionCam.transform.LookAt(bullet.transform.position);
			ActionCam.transform.position = hiter.PositionFocusOffset + target.transform.position + (target.transform.forward * 5);
			ActionCam.transform.position = TerrainFloor(ActionCam.transform.position);
			ActionCam.Slowmotion(0.1f,0.05f);
			ActionCam.ActionBullet(1f);
			locked = true;
		}
		base.TargetDetected (target, bullet,hiter);
	}
	
	public override void TargetHited (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}
		ActionCam.ObjectTarget = target;
		if(ActionCam.InAction){
			ActionCam.ActionBullet(1.2f);
			ActionCam.Slowmotion(0.01f,0.034f);
			if(!locked){
				ActionCam.transform.LookAt(bullet.transform.position);
				ActionCam.transform.position = hiter.PositionFocusOffset + target.transform.position + (target.transform.forward * 5);
				ActionCam.transform.position = TerrainFloor(ActionCam.transform.position);
			}
		}else{
			ActionCam.transform.LookAt(target.transform.position);
			ActionCam.transform.position = bullet.transform.position + (target.transform.forward * 5);
			ActionCam.transform.position = TerrainFloor(ActionCam.transform.position);
			ActionCam.ActionBullet(1.2f);
			ActionCam.Slowmotion(0.01f,0.034f);
		}
		
		base.TargetHited (target, bullet,hiter);
		
	}
}
