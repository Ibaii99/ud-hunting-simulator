using UnityEngine;
using System.Collections;

public class LevelsChoice : MonoBehaviour {

	public GameObject staglevel;
	public GameObject rabbitlevel;
	public GameObject wolflevel;
	public GameObject boarlevel;
	public GameObject eaglelevel;
	public GameObject ducklevel;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("SelectedAnimal") == 0)
		{
			staglevel.SetActive(true);
			rabbitlevel.SetActive(false);
			wolflevel.SetActive(false);
			boarlevel.SetActive(false);
			eaglelevel.SetActive(false);
			ducklevel.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("SelectedAnimal") == 1)
		{
			staglevel.SetActive(false);
			rabbitlevel.SetActive(true);
			wolflevel.SetActive(false);
			boarlevel.SetActive(false);
			eaglelevel.SetActive(false);
			ducklevel.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("SelectedAnimal") == 2)
		{
			staglevel.SetActive(false);
			rabbitlevel.SetActive(false);
			wolflevel.SetActive(true);
			boarlevel.SetActive(false);
			eaglelevel.SetActive(false);
			ducklevel.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("SelectedAnimal") == 3)
		{
			staglevel.SetActive(false);
			rabbitlevel.SetActive(false);
			wolflevel.SetActive(false);
			boarlevel.SetActive(true);
			eaglelevel.SetActive(false);
			ducklevel.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("SelectedAnimal") == 4)
		{
			staglevel.SetActive(false);
			rabbitlevel.SetActive(false);
			wolflevel.SetActive(false);
			boarlevel.SetActive(false);
			eaglelevel.SetActive(true);
			ducklevel.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("SelectedAnimal") == 5)
		{
			staglevel.SetActive(false);
			rabbitlevel.SetActive(false);
			wolflevel.SetActive(false);
			boarlevel.SetActive(false);
			eaglelevel.SetActive(false);
			ducklevel.SetActive(true);
		}


		//Stag Levele
		PlayerPrefs.SetInt ("Staglevel1", 0);
		PlayerPrefs.SetInt ("Staglevel2", 0);
		PlayerPrefs.SetInt ("Staglevel3", 0);
		PlayerPrefs.SetInt ("Staglevel4", 0);
		PlayerPrefs.SetInt ("Staglevel5", 0);
		PlayerPrefs.SetInt ("Staglevel6", 0);
		PlayerPrefs.SetInt ("Staglevel7", 0);
		PlayerPrefs.SetInt ("Staglevel8", 0);
		//Rabbit Levels
		PlayerPrefs.SetInt ("RabbitLevel1", 0);
		PlayerPrefs.SetInt ("RabbitLevel2", 0);
		PlayerPrefs.SetInt ("RabbitLevel3", 0);
		PlayerPrefs.SetInt ("RabbitLevel4", 0);
		PlayerPrefs.SetInt ("RabbitLevel5", 0);
		PlayerPrefs.SetInt ("RabbitLevel6", 0);
		PlayerPrefs.SetInt ("RabbitLevel7", 0);
		PlayerPrefs.SetInt ("RabbitLevel8", 0);
		//wolf Levels
		PlayerPrefs.SetInt ("Wolflevel1", 0);
		PlayerPrefs.SetInt ("Wolflevel2", 0);
		PlayerPrefs.SetInt ("Wolflevel3", 0);
		PlayerPrefs.SetInt ("Wolflevel4", 0);
		PlayerPrefs.SetInt ("Wolflevel5", 0);
		PlayerPrefs.SetInt ("Wolflevel6", 0);
		PlayerPrefs.SetInt ("Wolflevel7", 0);
		PlayerPrefs.SetInt ("Wolflevel8", 0);
		//boar Levels
		PlayerPrefs.SetInt ("Boarlevel1", 0);
		PlayerPrefs.SetInt ("Boarlevel2", 0);
		PlayerPrefs.SetInt ("Boarlevel3", 0);
		PlayerPrefs.SetInt ("Boarlevel4", 0);
		PlayerPrefs.SetInt ("Boarlevel5", 0);
		PlayerPrefs.SetInt ("Boarlevel6", 0);
		PlayerPrefs.SetInt ("Boarlevel7", 0);
		PlayerPrefs.SetInt ("Boarlevel8", 0);
		//Eagle Levels
		PlayerPrefs.SetInt ("Eaglelevel1", 0);
		PlayerPrefs.SetInt ("Eaglelevel2", 0);
		PlayerPrefs.SetInt ("Eaglelevel3", 0);
		PlayerPrefs.SetInt ("Eaglelevel4", 0);
		PlayerPrefs.SetInt ("Eaglelevel5", 0);
		PlayerPrefs.SetInt ("Eaglelevel6", 0);
		PlayerPrefs.SetInt ("Eaglelevel7", 0);
		PlayerPrefs.SetInt ("Eaglelevel8", 0);	
		//Duck Levels
		PlayerPrefs.SetInt ("Ducklevel1", 0);
		PlayerPrefs.SetInt ("Ducklevel2", 0);
		PlayerPrefs.SetInt ("Ducklevel3", 0);
		PlayerPrefs.SetInt ("Ducklevel4", 0);
		PlayerPrefs.SetInt ("Ducklevel5", 0);
		PlayerPrefs.SetInt ("Ducklevel6", 0);
		PlayerPrefs.SetInt ("Ducklevel7", 0);
		PlayerPrefs.SetInt ("Ducklevel8", 0);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
