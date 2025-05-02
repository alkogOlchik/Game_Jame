using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Platform : MonoBehaviour
{
    private PolygonCollider2D collider;
    public GameObject Player;
    public float height;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (!collider.isTrigger && (Input.GetKeyDown(KeyCode.S) || Player.transform.position.y < height))
            collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Player.transform.position.y > height)
        {
            collider.isTrigger = false;
        }

    }
}
