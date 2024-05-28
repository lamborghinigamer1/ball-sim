using Godot;
using System;

public partial class CameraController : Camera2D
{
	private Rect2 _currentResolution;

	private static bool Is16x9(Vector2 size)
	{
		return Math.Abs(size.X / size.Y - 16.0 / 9.0) < 0.01;
	}

	public override void _Process(double delta)
	{
		Rect2 resolution = GetViewport().GetVisibleRect();

		if (resolution.Size != _currentResolution.Size)
		{
			if (Is16x9(resolution.Size))
			{
				Zoom = new Vector2(resolution.Size.X / 1152.0f * 2, resolution.Size.Y / 648.0f * 2);
			}
			else
			{
				// Adjust the viewport to maintain a 16:9 aspect ratio.
				float targetWidth = resolution.Size.Y * (16.0f / 9.0f);
				float targetHeight = resolution.Size.X * (9.0f / 16.0f);

				if (targetWidth <= resolution.Size.X)
				{
					Zoom = new Vector2(targetWidth / 1152.0f * 2, resolution.Size.Y / 648.0f * 2);
				}
				else
				{
					Zoom = new Vector2(resolution.Size.X / 1152.0f * 2, targetHeight / 648.0f * 2);
				}
			}

			GD.Print(Zoom);
			_currentResolution = resolution;
		}
	}
}
