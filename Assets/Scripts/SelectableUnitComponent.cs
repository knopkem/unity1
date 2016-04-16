using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class SelectableUnitComponent : MonoBehaviour
{
    public Transform target;
    public GameObject selectionCircle;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public bool isSelected()
    {
        return (selectionCircle != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            _agent.destination = target.position;
        }
      
    }
}