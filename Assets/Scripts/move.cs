﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
	
	// Update is called once per frame
	void Update () {
        Vector3 xyz = transform.position;
        xyz.x += 0.1f;
        transform.position = xyz;
	}
}
