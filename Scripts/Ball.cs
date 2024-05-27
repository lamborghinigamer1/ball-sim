using Godot;
using System;

public partial class Ball : RigidBody2D
{
	[Export]
	public float BounceForcePerPixel = 5;

	[Export]
	public float MaxSpeed = 10;

	private RayCast2D _groundCast;
	private RayCast2D _topCast;
	private RayCast2D _leftCast;
	private RayCast2D _rightCast;
	private RayCast2D _topRightCast;
	private RayCast2D _bottomRightCast;
	private RayCast2D _bottomLeftCast;
	private RayCast2D _topLeftCast;

	public override void _Ready()
	{
		_groundCast = GetNode<RayCast2D>("GroundCast");
		_topCast = GetNode<RayCast2D>("TopCast");
		_leftCast = GetNode<RayCast2D>("LeftCast");
		_rightCast = GetNode<RayCast2D>("RightCast");
		_bottomLeftCast = GetNode<RayCast2D>("BottomLeftCast");
		_topLeftCast = GetNode<RayCast2D>("TopLeftCast");
		_topRightCast = GetNode<RayCast2D>("TopRightCast");
		_bottomRightCast = GetNode<RayCast2D>("BottomRightCast");

		MaxSpeed *= 1000;
		BounceForcePerPixel *= 1000;
	}

	public override void _PhysicsProcess(double delta)
	{
		float currentRotation = RotationDegrees;
		_groundCast.RotationDegrees = (0 - currentRotation) % 360;
		_topCast.RotationDegrees = 180 - currentRotation;
		_rightCast.RotationDegrees = 270 - currentRotation;
		_leftCast.RotationDegrees = 90 - currentRotation;
		_bottomLeftCast.RotationDegrees = 45 - currentRotation;
		_bottomRightCast.RotationDegrees = -45 - currentRotation;
		_topRightCast.RotationDegrees = 225 - currentRotation;
		_topLeftCast.RotationDegrees = -225 - currentRotation;

		if (_groundCast.IsColliding())
		{
			Vector2 force = new(0, -BounceForcePerPixel);
			ApplyForce(force);
		}
		else if (_topCast.IsColliding())
		{
			Vector2 force = new(0, BounceForcePerPixel);
			ApplyForce(force);
		}
		else if (_leftCast.IsColliding())
		{
			Vector2 force = new(BounceForcePerPixel, 0);
			ApplyForce(force);
		}
		else if (_rightCast.IsColliding())
		{
			Vector2 force = new(-BounceForcePerPixel, 0);
			ApplyForce(force);
		}
		else if (_bottomLeftCast.IsColliding())
		{
			Vector2 force = new(BounceForcePerPixel, -BounceForcePerPixel);
			ApplyForce(force);
		}
		else if (_topLeftCast.IsColliding())
		{
			Vector2 force = new(BounceForcePerPixel, BounceForcePerPixel);
			ApplyForce(force);
		}
		else if (_topRightCast.IsColliding())
		{
			Vector2 force = new(-BounceForcePerPixel, BounceForcePerPixel);
			ApplyForce(force);
		}
		else if (_bottomRightCast.IsColliding())
		{
			Vector2 force = new(-BounceForcePerPixel, -BounceForcePerPixel);
			ApplyForce(force);
		}

		LimitSpeed();
	}

	private void ApplyForce(Vector2 force)
	{
		// Apply the force to the ball
		ApplyCentralForce(force);
	}

	private void LimitSpeed()
	{
		Vector2 velocity = LinearVelocity;
		float speed = velocity.Length();

		if (speed > MaxSpeed)
		{
			velocity = velocity.Normalized() * MaxSpeed;
			LinearVelocity = velocity;
		}
	}
}
