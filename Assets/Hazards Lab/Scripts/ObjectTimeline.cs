using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Hazards Lab/Object Timeline")]
public class ObjectTimeline : ScriptableObject
{
    public GameObject gameObject;
    public List<TimeslotAction> initActions;
    public List<TimeslotAction> actions;

    List<TimeslotAction> activeActions;

    List<TimeslotAction> actionsToBeRemoved;

    public void Begin(Transform parentTransform)
    {
        GameObject newGameObject = Instantiate(gameObject, parentTransform);

        for (int i = 0; i < actions.Count; i++)
        {
            actions[i] = Instantiate(actions[i]);
            actions[i].Initialize(newGameObject);
        }
        activeActions = new List<TimeslotAction>();
        actionsToBeRemoved = new List<TimeslotAction>();

        for (int i = 0; i < initActions.Count; i++)
        {
            initActions[i] = Instantiate(initActions[i]);
            initActions[i].Initialize(newGameObject);
            initActions[i].TakeAction(0);
        }
    }

    public bool ObjectUpdate(float time)
    {
        if (actions.Count == 0 && activeActions.Count == 0)
            return false;

        foreach (TimeslotAction action in actions)
        {
            if (time >= action.startTime)
            {
                actionsToBeRemoved.Add(action);
                activeActions.Add(action);
            }
        }

        while (actionsToBeRemoved.Count > 0)
        {
            actions.Remove(actionsToBeRemoved[0]);
            actionsToBeRemoved.RemoveAt(0);
        }

        foreach (TimeslotAction action in activeActions)
        {
            action.TakeAction(time);

            if (time - action.startTime > action.duration)
                actionsToBeRemoved.Add(action);
        }

        while (actionsToBeRemoved.Count > 0)
        {
            actionsToBeRemoved[0].Exit();
            activeActions.Remove(actionsToBeRemoved[0]);
            actionsToBeRemoved.RemoveAt(0);
        }
        return true;
    }
}
