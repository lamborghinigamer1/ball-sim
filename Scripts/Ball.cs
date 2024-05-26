using Godot;
using System;

public partial class Ball : RigidBody2D
{
	[Export]
	public float BounceForcePerPixel = 5;
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
	}
	public override void _Process(double delta)
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
			Vector2 force = new(0, -BounceForcePerPixel * 1000 * (float)delta);
			ApplyCentralImpulse(force);
		}

		if (_topCast.IsColliding())
		{
			Vector2 force = new(0, BounceForcePerPixel * 1000 * (float)delta);
			ApplyCentralImpulse(force);
		}

		if (_leftCast.IsColliding())
		{
			Vector2 force = new(BounceForcePerPixel * 1000 * (float)delta, 0);
			ApplyCentralImpulse(force);
		}

		if (_rightCast.IsColliding())
		{
			Vector2 force = new(-BounceForcePerPixel * 1000 * (float)delta, 0);
			ApplyCentralImpulse(force);
		}

		if (_bottomLeftCast.IsColliding())
		{
			Vector2 force = new(BounceForcePerPixel * 1000 * (float)delta, -BounceForcePerPixel * 1000 * (float)delta);
			ApplyCentralImpulse(force);
		}

		if (_topLeftCast.IsColliding())
		{
			Vector2 force = new(BounceForcePerPixel * 1000 * (float)delta, BounceForcePerPixel * 1000 * (float)delta);
			ApplyCentralImpulse(force);
		}

		if (_topRightCast.IsColliding())
		{
			Vector2 force = new(-BounceForcePerPixel * 1000 * (float)delta, BounceForcePerPixel * 1000 * (float)delta);
			ApplyCentralImpulse(force);
		}

		if (_bottomRightCast.IsColliding())
		{
			Vector2 force = new(-BounceForcePerPixel * 1000 * (float)delta, -BounceForcePerPixel * 1000 * (float)delta);
			ApplyCentralImpulse(force);
		}
	}
}
