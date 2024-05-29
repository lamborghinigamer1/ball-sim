extends Camera2D

var _currentResolution: Rect2

func _process(_delta):
	var resolution = get_viewport().get_visible_rect()

	if resolution.size != _currentResolution.size:
		if is_16x9(resolution.size):
			zoom = Vector2(resolution.size.x / 1152.0 * 2, resolution.size.y / 648.0 * 2)
		else:
			# Adjust the viewport to maintain a 16:9 aspect ratio.
			var targetWidth = resolution.size.y * (16.0 / 9.0)
			var targetHeight = resolution.size.x * (9.0 / 16.0)

			if targetWidth <= resolution.size.x:
				zoom = Vector2(targetWidth / 1152.0 * 2, resolution.size.y / 648.0 * 2)
			else:
				zoom = Vector2(resolution.size.x / 1152.0 * 2, targetHeight / 648.0 * 2)

		print(zoom)
		_currentResolution = resolution

func is_16x9(size: Vector2) -> bool:
	return abs(size.x / size.y - 16.0 / 9.0) < 0.01
