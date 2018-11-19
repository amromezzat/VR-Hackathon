using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardShipSlotScript : MonoBehaviour
{


    public GameObjectField selectedHazard;
    public GameEvent ChipInserted;
    public GameEvent ChipRemoved;
    public Vector3 EjectForceMultiplier;

    private GameObject equipedChip;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        HazardShipScript hazardShipScript = null;
        if (hazardShipScript = other.gameObject.GetComponent<HazardShipScript>())
        {
            equipedChip = other.gameObject;
            equipedChip.transform.parent = this.transform;
            hazardShipScript.GetComponent<Rigidbody>().isKinematic = true;
            hazardShipScript.transform.position = this.transform.position;
            hazardShipScript.transform.rotation = this.transform.rotation;

            selectedHazard.Value = hazardShipScript.HazardRoomPrefab;
            ChipInserted.Raise();
        }


    }


    private void OnTriggerExit(Collider other)
    {
        HazardShipScript hazardShipScript = null;
        if (hazardShipScript = other.gameObject.GetComponent<HazardShipScript>())
        {
          //  hazardShipScript.GetComponent<Rigidbody>().isKinematic = false;
            selectedHazard.Value = null;
            equipedChip = null;
            ChipRemoved.Raise();
        }

    }

    public void EjectChip()
    {
        Rigidbody rb;
        if (rb = equipedChip.GetComponent<Rigidbody>())
        {
            rb.isKinematic = false;
            rb.AddForce(EjectForceMultiplier);
        }
    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
}
