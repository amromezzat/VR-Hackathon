using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardShipSlotScript : MonoBehaviour {


    public GameObjectField selectedHazard;
    //public GameEvent RoomSelected;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        HazardShipScript hazardShipScript = null;
        if (hazardShipScript = collision.gameObject.GetComponent<HazardShipScript>())
        {
            hazardShipScript.transform.position = this.transform.position;
            hazardShipScript.transform.rotation = this.transform.rotation;

            selectedHazard.Value = hazardShipScript.HazardRoomPrefab;
            
        }



    }
}
