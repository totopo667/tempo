﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UtilitiesTests : MonoBehaviour
{

    [SerializeField] [Range(-180, 180)] private float minAngle;
    [SerializeField] [Range(-180, 180)] private float maxAngle;

    private Material mat;

    void OnDrawGizmos()
    {
        for (int i = 0; i < 200; i++)
        {
            Gizmos.DrawSphere(transform.position + Mathsfs.Random.InsideUnitCone(Vector3.up, maxAngle, minAngle), 0.02f);
        }   
    }

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Start() => InternalClock.emitter.AddListener(ChangeColor);

    private void Update()
    {
        float clock = InternalClock.GetPeriod(InternalClock.ClockFormat.Frequency);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InternalClock.SetPeriod(clock + 1f, InternalClock.ClockFormat.Frequency);
        }
    }

    private void TestClock()
    {
        Debug.Log(InternalClock.GetPeriod(InternalClock.ClockFormat.BPM));
    }

    private void ChangeColor()
    {
        if (mat.color == Color.red)
        {
            mat.color = Color.green;
        }
        else
        {
            mat.color = Color.red;
        }
    }
}
