extends RigidBody2D

## The max speed of the ball (px/s * 1000)
@export var max_speed: float = 10
## If this is disabled then the Max Speed doesn't do anything
@export var speed_limit = true

var bounce_factor: float = 1.0

func _ready() -> void:
	# Create a new PhysicsMaterial
	var bounce_material = PhysicsMaterial.new()
	# Set the bounce property
	bounce_material.bounce = bounce_factor
	# Disable friction
	bounce_material.friction = 0.0

	# Assign the material to the physics_material_override property
	self.physics_material_override = bounce_material

func _physics_process(_delta: float) -> void:
	limit_speed()

func limit_speed():
	if speed_limit:
		# Limit the speed of the ball
		var speed_in_thousand_pixels_a_second = max_speed * 1000
		var velocity = linear_velocity
		var speed = velocity.length()
		# Apply the speed is the speed 
		if speed > speed_in_thousand_pixels_a_second:
			velocity = velocity.normalized() * speed_in_thousand_pixels_a_second
			linear_velocity = velocity
