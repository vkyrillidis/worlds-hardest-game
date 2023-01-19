using Godot;
using System.Runtime.Remoting.Metadata;

public class Player : KinematicBody2D
{
	[Signal]
	public delegate void GameWon();

	[Signal]
	public delegate void PlayerDied();

	[Export]
	public int speed = 400;

	public Vector2 velocity = new Vector2();

	public Vector2 startPosition = new Vector2();


	public override void _Ready()
	{
		startPosition = Position;
	}

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

		for (int i = 0; i < GetSlideCount(); i++)
		{
			var collision = GetSlideCollision(i);
			if (collision.Collider is Enemy)
			{
				EmitSignal(nameof(PlayerDied));
				Position = startPosition;
				break;
			}
		}
	}

	private void _on_End_body_entered(object body)
	{
		EmitSignal(nameof(GameWon));
	}
}
