using Godot;

public class Player : KinematicBody2D
{
	[Export]
	public int speed = 400;

	public Vector2 velocity = new Vector2();

	public void GetInput()
	{
		velocity = new Vector2();

		if (Input.IsActionPressed("move_right"))
			velocity.x += 1;

		if (Input.IsActionPressed("move_left"))
			velocity.x -= 1;

		if (Input.IsActionPressed("move_down"))
			velocity.y += 1;

		if (Input.IsActionPressed("move_up"))
			velocity.y -= 1;

		velocity = velocity.Normalized() * speed;
	}

	public override void _PhysicsProcess(float delta)
	{
		GetInput();
		velocity = MoveAndSlide(velocity);
	}
}
