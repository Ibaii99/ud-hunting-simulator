using UnityEngine;
using System.Collections;

public class AP_FastHit : AS_ActionPreset {

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
	
	public override void TargetDetected (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}

		base.TargetDetected (target, bullet,hiter);
	}
	
	public override void TargetHited (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}
		ActionCam.ObjectTarget = target;
		ActionCam.transform.LookAt(target.transform.position);
		ActionCam.transform.position = hiter.PositionFocusOffset + target.transform.position + (target.transform.forward * 5);
		ActionCam.transform.position = TerrainFloor(ActionCam.transform.position);
		ActionCam.ActionBullet(1.0f);
		base.TargetHited (target, bullet,hiter);

	}
}
