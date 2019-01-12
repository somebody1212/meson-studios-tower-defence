using Godot;
using System;

public class Player : KinematicBody2D
{
	
	const float SPEED = 6000f;
	const float GRAVITY = 1000f;
	const float JUMP_POWER = 250f;
	Vector2 FLOOR = new Vector2(0,-1);
	
	Vector2 Velocity = new Vector2(0,0);
	
	bool OnGround = false;
	
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _PhysicsProcess(float Delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.
		if (Input.IsActionPressed("ui_right")) {
			Velocity.x = SPEED * Delta;
		}
		else if (Input.IsActionPressed("ui_left")) {
			Velocity.x = -SPEED * Delta;
		}
		else {
			Velocity.x = 0;
		}
		
		if (Input.IsActionPressed("ui_up")) {
			if (OnGround == true) {
				Velocity.y = -JUMP_POWER;
				OnGround = false;
			}
		}
		
		GD.Print(Delta);
		
		Velocity.y += GRAVITY * Delta;
		
		if (IsOnFloor()) {
			OnGround = true;
		}
		else {
			OnGround = false;
		}
		
		MoveAndSlide(Velocity,FLOOR);
        
    }
}
