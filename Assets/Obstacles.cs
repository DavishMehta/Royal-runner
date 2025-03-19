using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacles : MonoBehaviour
{
    public bool is_dead = false;
    private void Start()
    {
       this.gameObject.tag = "Obstacle";
    }
}
