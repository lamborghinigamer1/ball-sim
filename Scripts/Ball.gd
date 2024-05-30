extends RigidBody2D

@export var BounceForcePerPixel: float = 5.0
@export var MaxSpeed: float = 10.0

var _groundCast: RayCast2D
var _topCast: RayCast2D
var _leftCast: RayCast2D
var _rightCast: RayCast2D
var _topRightCast: RayCast2D
var _bottomRightCast: RayCast2D
var _bottomLeftCast: RayCast2D
var _topLeftCast: RayCast2D
var _audioPlayer: AudioStreamPlayer2D

func _ready():
	_groundCast = $GroundCast
	_topCast = $TopCast
	_leftCast = $LeftCast
	_rightCast = $RightCast
	_bottomLeftCast = $BottomLeftCast
	_topLeftCast = $TopLeftCast
	_topRightCast = $TopRightCast
	_bottomRightCast = $BottomRightCast
	_audioPlayer = $AD

	MaxSpeed *= 1000
	BounceForcePerPixel *= 1000

func _physics_process(_delta: float):
	var currentRotation = rotation_degrees
	_groundCast.rotation_degrees = fmod((0 - currentRotation), 360)
	_topCast.rotation_degrees = fmod((180 - currentRotation), 360)
	_rightCast.rotation_degrees = fmod((270 - currentRotation), 360)
	_leftCast.rotation_degrees = fmod((90 - currentRotation), 360)
	_bottomLeftCast.rotation_degrees = fmod((45 - currentRotation), 360)
	_bottomRightCast.rotation_degrees = fmod((315 - currentRotation), 360)
	_topRightCast.rotation_degrees = fmod((225 - currentRotation), 360)
	_topLeftCast.rotation_degrees = fmod((135 - currentRotation), 360)

	if _groundCast.is_colliding():
		var force = Vector2(0, -BounceForcePerPixel)
		custom_force(force)
	elif _topCast.is_colliding():
		var force = Vector2(0, BounceForcePerPixel)
		custom_force(force)
	elif _leftCast.is_colliding():
		var force = Vector2(BounceForcePerPixel, 0)
		custom_force(force)
	elif _rightCast.is_colliding():
		var force = Vector2( - BounceForcePerPixel, 0)
		custom_force(force)
	elif _bottomLeftCast.is_colliding():
		var force = Vector2(BounceForcePerPixel, -BounceForcePerPixel)
		custom_force(force)
	elif _topLeftCast.is_colliding():
		var force = Vector2(BounceForcePerPixel, BounceForcePerPixel)
		custom_force(force)
	elif _topRightCast.is_colliding():
		var force = Vector2( - BounceForcePerPixel, BounceForcePerPixel)
		custom_force(force)
	elif _bottomRightCast.is_colliding():
		var force = Vector2( - BounceForcePerPixel, -BounceForcePerPixel)
		custom_force(force)

	limit_speed()

func custom_force(force: Vector2):
	# Apply the force to the ball
	_audioPlayer.play()
	apply_central_force(force)

func limit_speed():
	var velocity = linear_velocity
	var speed = velocity.length()

	if speed > MaxSpeed:
		velocity = velocity.normalized() * MaxSpeed
		linear_velocity = velocity
