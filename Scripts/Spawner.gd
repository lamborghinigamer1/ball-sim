extends Node2D

@export var balls: int = 1
@export var ball_scene: PackedScene

func _ready():
	Spawn()

func Spawn():
	for i in range(0, balls):
		print("Spawned ball")
		var ball = ball_scene.instantiate()
		add_child(ball)
