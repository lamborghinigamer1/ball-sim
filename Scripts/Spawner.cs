using Godot;
using System;

public partial class Spawner : Node2D
{
	[Export]
	public int Balls = 1;

	[Export]
	public PackedScene BallScene { get; set; }

	private bool _doneSpawning = false;

	public override void _Ready()
	{

	}

	private void Spawn()
	{
		if (!_doneSpawning)
		{
			for (int i = 0; i < Balls; i++)
			{
				GD.Print("Spawned ball");
				Ball ball = BallScene.Instantiate<Ball>();
				ball.MaxSpeed = 10;
				ball.BounceForcePerPixel = 5;
				AddChild(ball);
			}
			_doneSpawning = true;
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Spawn();
	}
}
