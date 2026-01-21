using Godot;
using System;

public partial class Player : CharacterBody3D
{
	private const float SPEED = 10.0f;
	private const float DECELERATION_SPEED = SPEED * 0.1f;

	private const float JUMP_FORCE = 10f;
	private const float GRAVITY_SPEED = 20f;

	[Export]
	public Camera3D camera;
	private float upward_force = 0f;

	public override void _Ready()
	{
		GD.Print("player ready");
	}

	public override void _PhysicsProcess(double delta)
	{
		Rotation = new Vector3(Rotation.X, camera.GlobalRotation.Y, Rotation.Z);

		Vector3 velocity = Velocity;

		if (IsOnFloor())
		{
			velocity.Y = 0;
		}
		else
		{
			velocity.Y -= GRAVITY_SPEED * (float)delta;
		}

		Vector3 moveVec = Vector3.Zero;

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JUMP_FORCE;
		}

		if (Input.IsActionPressed("go_front"))
			moveVec.Z += -1;
		if (Input.IsActionPressed("go_back"))
			moveVec.Z += 1;
		if (Input.IsActionPressed("go_left"))
			moveVec.X += -1;
		if (Input.IsActionPressed("go_right"))
			moveVec.X += 1;

		moveVec *= SPEED;

		moveVec = moveVec.Rotated(Vector3.Up, Rotation.Y);

		if (moveVec.Z != 0)
		{
			velocity.Z = moveVec.Z;
		}
		else
		{
			velocity.Z = Mathf.MoveToward(velocity.Z, 0, DECELERATION_SPEED);
		}

		if (moveVec.X != 0)
		{
			velocity.X = moveVec.X;
		}
		else
		{
			velocity.X = Mathf.MoveToward(velocity.X, 0, DECELERATION_SPEED);
		}

		// upward_force and related logic remain commented out exactly
		// upward_force = move_toward(upward_force, 0, (GRAVITY_FACTOR / 100.0) * upward_force)
		// velocity.y = move_vec.y + upward_force

		Velocity = velocity;
		MoveAndSlide();
	}
}
