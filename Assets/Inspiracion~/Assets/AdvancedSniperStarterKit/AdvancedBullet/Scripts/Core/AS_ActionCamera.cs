using UnityEngine;
using System.Collections;

public class AS_ActionCamera : MonoBehaviour
{
	
	public AS_ActionPreset[] ActionPresets;
	[HideInInspector]
	public GameObject ObjectTarget, ObjectFollowing, ObjectTargetRoot;
	[HideInInspector]
	public Vector3 Position, PositionOffset, PositionFollowOffset;
	[HideInInspector]
	public Vector3 PositionLookAt;
	[HideInInspector]
	public float Raduis = 5;
	[HideInInspector]
	public float TimeDuration = 2;
	[HideInInspector]
	public float SlowTimeDuration = 2;
	[HideInInspector]
	public float FollowingMult = 10;
	[HideInInspector]
	public float FollowingReduceMult = 20;
	[HideInInspector]
	public int PresetIndex = -1;
	[HideInInspector]
	public bool InAction;
	[HideInInspector]
	public bool Detected;
	[HideInInspector]
	public bool HitTarget;
	public float TimeChangeSpeed = 10;
	private static float initialFixedTimeStep = 1;
	private float timeTemp, slowtimeTemp;
	private bool[] cameraEnabledTemp;
	private bool[] audiolistenerEnabledTemp;
	private float timeScaleTarget = 1;
	[HideInInspector]
	public bool cameraTemp;
	
	public AS_ActionPreset GetPresets ()
	{
		if (ActionPresets.Length <= 0) {
			return null;	
		}
		AS_ActionPreset res = ActionPresets [Random.Range (0, ActionPresets.Length)];
		if (PresetIndex != -1 && PresetIndex < ActionPresets.Length) {
			res = ActionPresets [PresetIndex];
		}
		//Debug.Log (res.name);
		return res;
	}
	
	void Start ()
	{
		initialFixedTimeStep = Time.fixedDeltaTime;
	}
	
	public void ActionBullet (float actionduration)
	{
		TimeDuration = actionduration;
		setTarget ();
	}
	
	public void Slowmotion (float timescale, float slowduration)
	{
		TimeSet (timescale);
		SlowTimeDuration = slowduration;
		slowtimeTemp = Time.time;
	}
	
	public void TimeSet (float scale)
	{
		timeScaleTarget = scale;
	}
	
	private void setTarget ()
	{
		timeTemp = Time.time;
		InAction = true;
		CameraActive ();
		this.GetComponent<Camera>().enabled = true;
		if (this.GetComponent<Camera>().gameObject.GetComponent<AudioListener> ())
			this.GetComponent<Camera>().gameObject.GetComponent<AudioListener> ().enabled = true;
	}
	
	private Camera[] cams;
	
	public void CameraActive ()
	{
		if (!cameraTemp) {
			cams = (Camera[])GameObject.FindObjectsOfType (typeof(Camera));
			audiolistenerEnabledTemp = new bool[cams.Length];
			cameraEnabledTemp = new bool[cams.Length];
			for (int i=0; i<cams.Length; i++) {
				cameraEnabledTemp [i] = cams [i].enabled;
				
				if (cams [i].gameObject.GetComponent<AudioListener> ()) {
					audiolistenerEnabledTemp [i] = cams [i].gameObject.GetComponent<AudioListener> ().enabled;
				}
				
				cams [i].enabled = false;
				if (cams [i].gameObject.GetComponent<AudioListener> ()) {
					cams [i].gameObject.GetComponent<AudioListener> ().enabled = false;
				}
			}
			//Debug.Log("Action Cameras");
			cameraTemp = true;
		}
	}
	
	public void CameraRestore ()
	{
		cameraTemp = false;
		Camera[] cams = (Camera[])GameObject.FindObjectsOfType (typeof(Camera));
		if (cameraEnabledTemp != null && cams != null) {
			if (cams.Length > 0 && cameraEnabledTemp.Length > 0 && cameraEnabledTemp.Length == cams.Length) {
				for (int i=0; i<cams.Length; i++) {
					cams [i].enabled = cameraEnabledTemp [i];	
					if (cams [i].gameObject.GetComponent<AudioListener> ()) {
						cams [i].gameObject.GetComponent<AudioListener> ().enabled = audiolistenerEnabledTemp [i];
					}
				}
			}
		}
		//Debug.Log("Restore Cameras");
	}
	
	public void ClearTarget ()
	{
		InAction = false;
		HitTarget = false;
		Detected = false;
		ObjectFollowing = null;
		ObjectTarget = null;
		ObjectTargetRoot = null;
		CameraRestore ();
	}
	
	Vector3 Direction (Vector3 point1, Vector3 point2)
	{
		return (point1 - point2).normalized;
	}
	
	void FixedUpdate ()
	{
		if (InAction) {
			
			if (ObjectTarget) {
				PositionLookAt = ObjectTarget.transform.position;
				Vector3 positionLook = ObjectTarget.transform.position;
				
			}
			if (ObjectFollowing) {
				Vector3 positionTarget = (ObjectFollowing.transform.position + PositionOffset + PositionFollowOffset);
				PositionOffset = Vector3.Lerp (PositionOffset, Vector3.up * 0.1f, Time.fixedDeltaTime * FollowingReduceMult);
				this.transform.position = Vector3.Lerp (this.transform.position, positionTarget, Time.fixedDeltaTime * FollowingMult);
			}
			Quaternion rotation = Quaternion.LookRotation (PositionLookAt - this.transform.position);
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, rotation, Time.fixedDeltaTime * 50);
			
		}
	}
	
	void Update ()
	{
		float timescaleUp = (timeScaleTarget - Time.timeScale) * (Time.deltaTime * TimeChangeSpeed);
		if(Time.timeScale + timescaleUp >= 0 && Time.timeScale + timescaleUp <= 100){
			Time.timeScale += timescaleUp; 
		}
		
		
		Time.fixedDeltaTime = (initialFixedTimeStep * Time.timeScale);	
		
		if (InAction) {
			if (Time.time >= timeTemp + TimeDuration) {
				ClearTarget ();
			}
		}
		if (Time.time >= slowtimeTemp + SlowTimeDuration) {
			TimeSet (1);	
		}
		if (cameraTemp) {
			for (int i=0; i<cams.Length; i++) {
				if (cams [i] != this.GetComponent<Camera>()) {
					cams [i].enabled = false;	
				}
			}
		}	
	}
	
	
	
}
