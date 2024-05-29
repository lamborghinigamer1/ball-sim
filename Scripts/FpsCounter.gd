extends Label

var fps: int

func _process(_delta: float) -> void:
    fps = int(floor(Engine.get_frames_per_second()))
    text = "FPS: %d" % fps