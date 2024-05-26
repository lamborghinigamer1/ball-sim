using Godot;
using System;

public partial class FpsCounter : Label
{
	private int fps;

	public override void _Process(double delta)
	{
		fps = (int)Math.Floor(Engine.GetFramesPerSecond());

		Text = $"FPS: {fps}";
	}
}
