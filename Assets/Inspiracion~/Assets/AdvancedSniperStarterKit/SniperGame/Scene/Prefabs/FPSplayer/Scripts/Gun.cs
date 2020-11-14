using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]


public class Gun : MonoBehaviour
{
	public float originalWidth = 1024.0f;
	public float originalHeight = 768.0f;
	public Vector3 scale;

	public bool Active = true;
	public GameObject Bullets; // Bullet prefeb
	public float LifeTimeBullet = 5;
	public GameObject Shell; // Shell prefeb
	public Transform ShellSpawn; // shell spawing position
	public GameObject NormalCamera;// FPS camera
	public float FireRate = 0.2f;
	public float KickPower = 10;
	public float[] ZoomFOVLists;
	public int IndexZoom = 0;
	public float CooldownTime = 0.8f;
	public float BoltTime = 0.35f;
	public Texture2D CrosshairImg, CrosshairZoom;
	public bool HideGunWhileZooming = true;
	public AudioClip SoundGunFire;
	public AudioClip SoundBoltEnd;
	public AudioClip SoundBoltStart;
	public AudioClip SoundReloadStart;
	public AudioClip SoundReloadEnd;
	public AudioClip bgSound;
	public AudioClip Button_Audio;
	public float MouseSensitive = 1;
	public bool Zooming;
	public bool SemiAuto;
	public bool InfinityAmmo = true;
	public int BulletNum = 1;
	public int Clip = 30;
	public int ClipSize = 30;
	public int AmmoIn = 1;
	public int AmmoPack = 90;
	public int AmmoPackMax = 90;
	private float MouseSensitiveZoom = 0.5f;
	private bool boltout;
	private float timefire = 0;
	private int gunState = 0;
	private AudioSource audiosource;
	private float fovTemp;
	private float cooldowntime = 0;
	private Quaternion rotationTemp;
	private Vector3 positionTemp;
	public string IdlePose = "Idle";
	public string ShootPose = "Shoot";
	public string ReloadPose = "Reload";
	public string BoltPose = "Bolt";
	[HideInInspector]
	public FPSController FPSmotor;


	
	void Start ()
	{
		GetComponent<Animation>().cullingType = AnimationCullingType.AlwaysAnimate;
		FPSmotor = transform.parent.GetComponent<FPSController> ();
		fovTemp = NormalCamera.GetComponent<Camera>().fieldOfView;
		Zooming = false;
		if (GetComponent<AudioSource>()) {
			audiosource = GetComponent<AudioSource>();	
		}
//		if (AmmoIn > 1)
//			AmmoIn = 1;


	}

	void Awake ()
	{
		rotationTemp = this.transform.localRotation;
		positionTemp = this.transform.localPosition;
		this.transform.localPosition = positionTemp - (Vector3.up);
	}
	
	public void SetActive (bool active)
	{
		Active = active;
		this.gameObject.SetActive(active);
		Zooming = false;
		IndexZoom = 2;
		this.transform.localPosition = positionTemp - (Vector3.up);	
	}
	
	void FixedUpdate ()
	{
		if (!FPSmotor || !Active)
			return;
		
		float magnitude = FPSmotor.motor.controller.velocity.magnitude * 0.5f;
		magnitude = Mathf.Clamp (magnitude, 0, 10);
		float swaySpeed = 0;
		float sizeY = 0.1f;
		float sizeX = 0.1f;
		// Gun sway volume depending on move velosity.
		if (magnitude > 5) {
			swaySpeed = 1.4f;
			sizeY = 0.2f;
			sizeX = 0.2f;
		} else {
			if (magnitude < 2.0f) {
				swaySpeed = 0;
				sizeY = 0.05f;
				sizeX = 0.05f;
			} else {
				swaySpeed = 1;
				sizeY = 0.1f;
				sizeX = 0.1f;	
				
			}
		}
		float swayY = (Mathf.Cos (Time.time * 10 * swaySpeed) * 0.3f) * sizeY;
		float swayX = (Mathf.Sin (Time.time * 5 * swaySpeed) * 0.2f) * sizeX;
		this.transform.localPosition = Vector3.Lerp (this.transform.localPosition, positionTemp + new Vector3 (swayX, swayY, 0), Time.fixedDeltaTime * 4);
		this.transform.localRotation = Quaternion.Lerp (this.transform.localRotation, Quaternion.Euler ((rotationTemp.eulerAngles.x + (FPSmotor.rotationDif.x)), (rotationTemp.eulerAngles.y + (FPSmotor.rotationDif.y)), (rotationTemp.eulerAngles.z + (FPSmotor.direction.x * 7))), Time.fixedDeltaTime * 3);
	}


	
	void Update ()
	{
		if (HideGunWhileZooming && FPSmotor && NormalCamera.GetComponent<Camera>().enabled) {
			FPSmotor.HideGun (!Zooming);
		}
		
		if (!GetComponent<Animation>() || !Active)
			return;
		
		
		switch (gunState) {
		case 0:
			// Start Bolt
			if (AmmoIn <= 0) {
				// Check Ammo in clip
				if (Clip > 0) {
					GetComponent<Animation>().clip = GetComponent<Animation>() [BoltPose].clip;
					GetComponent<Animation>().CrossFade (BoltPose, 0.5f, PlayMode.StopAll);
					gunState = 2;
					// scope rotation a bit when reloading
					if (FPSmotor && Zooming) {
						FPSmotor.CameraForceRotation (new Vector3 (0, 0, 20));
						FPSmotor.Stun (0.2f);
					}
					if (SoundBoltStart && audiosource != null) {
						if(PlayerPrefs.GetInt("FX")==1) 
						audiosource.PlayOneShot (SoundBoltStart);
					}
					Clip -= 1;
				} else {
					gunState = 3;	
				}
			}
			break;
		case 1:
			// Countdown to idle state
			if (Time.time >= cooldowntime + CooldownTime) {
				gunState = 0;
			}
			break;
		case 2:
			GetComponent<Animation>().Play ();
			// finish bold animation
			if (GetComponent<Animation>() [BoltPose].normalizedTime > BoltTime) {
				if (Shell && ShellSpawn) {
					if (!boltout) {
						GameObject shell = (GameObject)Instantiate (Shell, ShellSpawn.position, ShellSpawn.rotation);
						shell.GetComponent<Rigidbody>().AddForce (ShellSpawn.transform.right * 2);
						shell.GetComponent<Rigidbody>().AddTorque (Random.rotation.eulerAngles * 10);
						GameObject.Destroy (shell, 5);
						boltout = true;
						if (FPSmotor && Zooming) {
							FPSmotor.CameraForceRotation (new Vector3 (0, 0, -5));
							FPSmotor.Stun (0.1f);
						}
					}
				}
			}
			if (GetComponent<Animation>() [BoltPose].normalizedTime > 0.9f) {
				gunState = 0;

				if(PlayerPrefs.GetInt("Gun") == 1)
				{
					AmmoIn = 1;
				}
				if(PlayerPrefs.GetInt("Gun") == 2)
				{
					AmmoIn = 2;
				}
				if(PlayerPrefs.GetInt("Gun") == 3)
				{
					AmmoIn = 3;
				}
				if(PlayerPrefs.GetInt("Gun") == 4)
				{
					AmmoIn = 4;
				}
				if(PlayerPrefs.GetInt("Gun") == 5)
				{
					AmmoIn = 8;
				}
				if(PlayerPrefs.GetInt("Gun") == 6)
				{
					AmmoIn = 6;
				}
				if(PlayerPrefs.GetInt("Gun") == 7)
				{
					AmmoIn = 10;
				}
//				if(PlayerPrefs.GetInt("Gun") == 8)
//				{
//					AmmoIn = 10;
//				}
				GetComponent<Animation>().CrossFade (IdlePose);
				if (SoundBoltEnd && audiosource != null) {
					if(PlayerPrefs.GetInt("FX")==1) 
					audiosource.PlayOneShot (SoundBoltEnd);
				}
			}
			break;
		case 3:
			// Start Reloading
			if (GetComponent<Animation>() [ReloadPose] && AmmoPack > 0) {
				GetComponent<Animation>().clip = GetComponent<Animation>() [ReloadPose].clip;
				GetComponent<Animation>().CrossFade (ReloadPose, 0.5f, PlayMode.StopAll);
				gunState = 4;
				Zooming = false;
				if (SoundReloadStart && audiosource != null) {
					if(PlayerPrefs.GetInt("FX")==1) 
					audiosource.PlayOneShot (SoundReloadStart);
				}
			}
			break;
		case 4:
			if (GetComponent<Animation>() [ReloadPose]) {
				if (GetComponent<Animation>() [ReloadPose].normalizedTime > 0.9f) {
					gunState = 0;
					if (InfinityAmmo) {
						Clip = ClipSize;
					} else {
						if (AmmoPack >= ClipSize) {
							Clip = ClipSize;
							AmmoPack -= ClipSize;
						} else {
							Clip = AmmoPack;
							AmmoPack = 0;
						}
					}
					
					if (Clip > 0) {
						GetComponent<Animation>().CrossFade (IdlePose);
						if (SoundReloadEnd && audiosource != null) {
							if(PlayerPrefs.GetInt("FX")==1) 
							audiosource.PlayOneShot (SoundReloadEnd);
						}
					}
				}
			}
			break;
		}
	
		if (FPSmotor) {
			if (Zooming) {
				FPSmotor.sensitivityXMult = MouseSensitiveZoom;
				FPSmotor.sensitivityYMult = MouseSensitiveZoom;
				FPSmotor.Noise = true;
			} else {
				FPSmotor.sensitivityXMult = MouseSensitive;
				FPSmotor.sensitivityYMult = MouseSensitive;
				FPSmotor.Noise = false;
			}
		}
	
		if (Zooming) {
			if (ZoomFOVLists.Length > 0) {
				MouseSensitiveZoom = ((MouseSensitive * 0.16f) / 10) * ZoomFOVLists [IndexZoom];
				NormalCamera.GetComponent<Camera>().fieldOfView += (ZoomFOVLists [IndexZoom] - NormalCamera.GetComponent<Camera>().fieldOfView) / 10;
			}
		} else {
			NormalCamera.GetComponent<Camera>().fieldOfView += (fovTemp - NormalCamera.GetComponent<Camera>().fieldOfView) / 10;
		}

		if (audiosource != null) {
			audiosource.pitch = Time.timeScale;
			if (audiosource.pitch < 0.5f) {
				audiosource.pitch = 0.5f;
			}
		}
		
	}
	
	public void ZoomDelta (int plus)
	{
		if (!Active)
			return;
		
		if (plus > 0) {
			if (IndexZoom < ZoomFOVLists.Length - 1) {
				IndexZoom += 1;
			}
		} else {
			if (IndexZoom > 0) {
				IndexZoom -= 1;
			}
		}
	}

	public void Reload ()
	{
		if (gunState == 0) {
			gunState = 3;	
		}
	}
	
	public void  Zoom ()
	{
		Zooming = !Zooming;
	}

	public void  Shoot ()
	{
		if (!Active)
			return;
		
		if (timefire + FireRate < Time.time) {
			if (gunState == 0) {
				if (AmmoIn > 0) {
					if (FPSmotor)
						FPSmotor.Stun (KickPower);
					if (SoundGunFire && audiosource != null) {
						if(PlayerPrefs.GetInt("FX")==1) 
							audiosource.PlayOneShot (SoundGunFire);
					}
					for (int i=0; i<BulletNum; i++) {
						if (Bullets) {
							Vector3 point = NormalCamera.GetComponent<Camera>().ScreenToWorldPoint (new Vector3 (0, 0, NormalCamera.GetComponent<Camera>().nearClipPlane));
							GameObject bullet = (GameObject)Instantiate (Bullets, point, NormalCamera.gameObject.transform.rotation);
							bullet.transform.forward = NormalCamera.transform.forward;
							Destroy (bullet, LifeTimeBullet);
						}	
					}
					boltout = false;
					GetComponent<Animation>().Stop ();
					GetComponent<Animation>().Play (ShootPose, PlayMode.StopAll);
					timefire = Time.time;
					cooldowntime = Time.time;
					if (!SemiAuto) {
						gunState = 1;
						AmmoIn -= 1;
					} else {
						
						if (Shell && ShellSpawn) {
							GameObject shell = (GameObject)Instantiate (Shell, ShellSpawn.position, ShellSpawn.rotation);
							shell.GetComponent<Rigidbody>().AddForce (ShellSpawn.transform.right * 2);
							shell.GetComponent<Rigidbody>().AddTorque (Random.rotation.eulerAngles * 10);
							GameObject.Destroy (shell, 5);
						}
						
						if (Clip > 0) {
							AmmoIn = 1;
							Clip -= 1;
						} else {
							gunState = 3;	
						}
					}
				}
			}
		}
	}
	
//	void OnGUI ()
//	{
//		if (!Active)
//			return;
//		
//		if (NormalCamera.camera.enabled) {
//			if (!Zooming) {
//				if (CrosshairImg) {
//					GUI.color = new Color (1, 1, 1, 0.8f);
//					GUI.DrawTexture (new Rect ((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f), (Screen.height * 0.5f) - (CrosshairImg.height * 0.5f), CrosshairImg.width, CrosshairImg.height), CrosshairImg);
//					GUI.color = Color.white;
//				}
//			} else {
//				if (CrosshairZoom) {
//					float scopeSize = (Screen.height * 1.1f);
//					GUI.DrawTexture (new Rect ((Screen.width * 0.5f) - (scopeSize * 0.5f), (Screen.height * 0.5f) - (scopeSize * 0.5f), scopeSize, scopeSize), CrosshairZoom);
//				}
//			}
//		}
//	}

	void OnGUI()
	{
		if (!Active)
			return;
		
		if (NormalCamera.GetComponent<Camera>().enabled) {
			if (!Zooming) {
				if (CrosshairImg) {
					GUI.color = new Color (1, 1, 1, 0.8f);
					GUI.DrawTexture (new Rect ((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f), (Screen.height * 0.5f) - (CrosshairImg.height * 0.5f), CrosshairImg.width, CrosshairImg.height), CrosshairImg);
					GUI.color = Color.white;
				}
			} else {
				scale.x = Screen.width/originalWidth; // calculate hor scale
				scale.y = Screen.height/originalHeight; // calculate vert scale
				scale.z = 1.0f;
				var svMat= GUI.matrix; 
				GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity,scale);
				if (CrosshairZoom) {
					float scopeSize = (Screen.height * 1.1f);
					GUI.DrawTexture (new Rect(0,0, originalWidth, originalHeight) , CrosshairZoom);
				}
				GUI.matrix = svMat;
			}
		}
	
	}

}