extends KinematicBody2D

const SPEED = 60
const GRAVITY = 10
const JUMP_POWER = 250
const FLOOR = Vector2(0, -1)

var velocity = Vector2()

var on_ground = false
var in_air = false

func _physics_process(delta):
	
	if Input.is_action_pressed("ui_right"):
		velocity.x = SPEED
	elif Input.is_action_pressed("ui_left"):
		velocity.x = -SPEED
	else:
		velocity.x = 0
	
	if Input.is_action_pressed("ui_up"):
		if on_ground == true:
			velocity.y = JUMP_POWER * -1
			on_ground = false
			in_air = true
	if Input.is_action_pressed("ui_down"):
		if in_air == true:
			velocity.y = JUMP_POWER * 1.2
			on_ground = true
			in_air = false
	if Input.is_action_pressed("ui_shift"):
		if velocity.x > 0 == true:
				velocity.x = SPEED * 1.2
				velocity.y = GRAVITY * 0.2
		if velocity.x < 0 == true:
				velocity.x = SPEED * -1.2
				velocity.y = GRAVITY * 0.2
	
	velocity.y += GRAVITY
	
	if is_on_floor():
		on_ground = true
		in_air = false
	else:
		on_ground = false
		in_air = true
	
	velocity = move_and_slide(velocity, FLOOR)
