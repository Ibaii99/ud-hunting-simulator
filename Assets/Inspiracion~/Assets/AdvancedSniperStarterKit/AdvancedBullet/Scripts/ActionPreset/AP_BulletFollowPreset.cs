using UnityEngine;
using System.Collections;

public class AP_BulletFollowPreset : AS_ActionPreset {

	bool locked = false;

	public override void FirstDetected (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}
		locked = false;
		if(!ActionCam.InAction){
			ActionCam.ObjectTarget = bullet;
			ActionCam.ObjectFollowing = bullet;
			ActionCam.PositionOffset = (bullet.transform.right + bullet.transform.up) * 2;
			ActionCam.transform.LookAt(bullet.transform.position);
			ActionCam.transform.position = bullet.transform.position + ((bullet.transform.forward - bullet.transform.forward) * 5);
			ActionCam.ActionBullet(1.0f);
			ActionCam.Slowmotion(0.3f,0.5f);
			ActionCam.FollowingReduceMult = 30;
			ActionCam.FollowingMult = 20;
			locked = true;
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

		if(locked && ActionCam.ObjectFollowing != null){
			ActionCam.ObjectTarget = target;
			ActionCam.FollowingReduceMult = 80;
			ActionCam.FollowingMult = 100;
			ActionCam.Slowmotion(0.3f,0.2f);	
			ActionCam.ActionBullet(2.0f);
		}
		if(!locked || ActionCam.ObjectFollowing == null){
			ActionCam.ObjectTarget = target;
			ActionCam.transform.LookAt(bullet.transform.position);
			ActionCam.transform.position = hiter.PositionFocusOffset + target.transform.position + (target.transform.forward * 5);
			ActionCam.transform.position = TerrainFloor(ActionCam.transform.position);
			ActionCam.Slowmotion(0.1f,0.05f);
			ActionCam.ActionBullet(2.0f);	
		}
		base.TargetDetected (target, bullet,hiter);
	}
	
	public override void TargetHited (GameObject target, GameObject bullet,AS_BulletHiter hiter)
	{
		if(!ActionCam){
			return;	
		}
		ActionCam.ObjectTarget = target;
		if(locked && ActionCam.ObjectFollowing != null){
			ActionCam.ActionBullet(0.2f);
			ActionCam.Slowmotion(0.1f,0.2f);
		}
		if(!locked || ActionCam.ObjectFollowing == null){
			ActionCam.transform.LookAt(target.transform.position);
			ActionCam.transform.position = bullet.transform.position + (target.transform.forward * 5);
			ActionCam.transform.position = TerrainFloor(ActionCam.transform.position);
			ActionCam.ActionBullet(1.2f);
			ActionCam.Slowmotion(0.01f,0.034f);
		}	
		ActionCam.ObjectFollowing = null;
		base.TargetHited (target, bullet,hiter);
		
	}
}
