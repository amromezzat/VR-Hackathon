using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabTestInstance : MonoBehaviour
{

    public List<ObjectTimeline> objectsTimelines;

    public GameEvent onExit;

    bool updating;

    float time;

    // Use this for initialization
    void Start()
    {
        for(int i=0;i< objectsTimelines.Count;i++)
        {
            objectsTimelines[i] = Instantiate(objectsTimelines[i]);
            objectsTimelines[i].Begin(transform);
        }
    }

    public void Begin()
    {
        updating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!updating)
            return;

        time += Time.deltaTime;

        bool keepUpdating = false;

        foreach (ObjectTimeline objectTimeline in objectsTimelines)
        {
            keepUpdating |= objectTimeline.ObjectUpdate(time);
        }
        if (!keepUpdating)
        {
            onExit.Raise();
            updating = false;
        }
    }


}
