using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   
    [SerializeField] private Transform player;
    [SerializeField] private float h;
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y*h, transform.position.z);
    }
}

