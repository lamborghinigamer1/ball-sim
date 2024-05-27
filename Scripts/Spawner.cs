using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export]
	public int Balls = 1;

	[Export]
	public PackedScene BallScene { get; set; }

	public override void _Ready()
	{
		Spawn();
	}

	private void Spawn()
	{
		for (int i = 0; i < Balls; i++)
		{
			GD.Print("Spawned ball");
			Ball ball = BallScene.Instantiate<Ball>();
			ball.MaxSpeed = 10;
			ball.BounceForcePerPixel = 5;
			AddChild(ball);
		}
	}
}
