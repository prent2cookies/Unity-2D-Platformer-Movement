﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToWall : AbstractBehavior {

    public bool onWallDetected;

    protected float defaultGravityScale;
    protected float defaultDrag;

	// Use this for initialization
	void Start () {
        defaultGravityScale = body2D.gravityScale;
        defaultDrag = body2D.drag;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        if (collisionState.onWall)
        {
            if (!onWallDetected)
            {
                OnStick();
                ToggleScripts(false);
                onWallDetected = true;
            }
        }
        else
        {
            if (onWallDetected)
            {
                OffWall();
                ToggleScripts(true);
                onWallDetected = false;
            }
        }
        
	}

    protected virtual void OnStick()
    {
        if(!collisionState.standing & body2D.velocity.y > 0)
        {
            Debug.Log("This outputs");
            body2D.gravityScale = 0;
            body2D.drag = 100;
        }
    }

    protected virtual void OffWall()
    {
        if (body2D.gravityScale != defaultGravityScale)
        {
            body2D.gravityScale = defaultGravityScale;
            body2D.drag = defaultDrag;
        }
    }
}
