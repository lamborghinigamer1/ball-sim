extends Node2D

@export var Balls: int = 1
@export var BallScene: PackedScene

func _ready():
	Spawn()

func Spawn():
	for i in range(Balls):
		print("Spawned ball")
		var ball = BallScene.instantiate()
		ball.MaxSpeed = 10
		ball.BounceForcePerPixel = 5
		add_child(ball)
