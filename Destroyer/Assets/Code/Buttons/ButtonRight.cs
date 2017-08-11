﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ButtonRight : MonoBehaviour
{
    [SerializeField]
    private MoveHero hero;

#if UNITY_ANDROID
    void FixedUpdate()
    { if (hero.H != 0) hero.MoveLeftRight(); }
    public void OnMouseDown()
    { hero.H = 1; }
    public void OnMouseUp()
    { hero.H = 0; }
#endif
}
