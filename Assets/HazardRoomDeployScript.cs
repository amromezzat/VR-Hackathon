using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRoomDeployScript : MonoBehaviour
{

    public GameObjectField selectedHazard;
    public Transform SpawnPosition;

    public GameEvent onDestroy;
    public GameEvent onLoad;
    // Use this for initialization
    void Start()
    {
        selectedHazard.onValueChanged.AddListener(OnSelectedHazardChanged);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnSelectedHazardChanged(GameObject selectedHazard)
    {
        if (selectedHazard)
        {
            //clean any old remainings
            DestroyOld();

            {
                GameObject.Instantiate(selectedHazard, SpawnPosition.transform.position, Quaternion.identity, SpawnPosition);
                StartCoroutine(FireLoadEvent());
            }
        }
    }

    private IEnumerator FireLoadEvent()
    {
        yield return new WaitForEndOfFrame();
        onLoad.Raise();
    }


    public void DestroyOld()
    {
        if (SpawnPosition.childCount > 0)
        {
            onDestroy.Raise();
            for (int i = 0; i < SpawnPosition.childCount; i++)
            {
                Destroy(SpawnPosition.GetChild(i).gameObject);
            }
        }
    }
}
