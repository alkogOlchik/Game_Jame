using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    public float posY;
    public bool isStop;
    public float lenth;

    protected bool updateEnabled;
    protected virtual void Start()
    {
        
    }

    protected virtual void Awake()
    {
        if (!player)
            player = FindObjectOfType<PLayer_Movement>().transform;
        isStop = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (updateEnabled)
        {
            if (!isStop)
            {
                pos.x = player.position.x;
                pos.y = player.position.y + posY;
                pos.z = -1f;
                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
            }
            if (player.position.x >= lenth)
                isStop = true;
            else
                isStop = false;
        }
        
        

    
    }
}