using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventListenerEditor : Editor
{
    GameEvent gameEvent;

    private void OnEnable()
    {
        gameEvent = (GameEvent)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        if (GUILayout.Button("Raise"))
            gameEvent.Raise();
    }
}