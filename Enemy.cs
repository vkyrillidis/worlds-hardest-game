using Godot;

public class Enemy : KinematicBody2D
{
	[Export]
	public int speed = 5;

	public Vector2 velocity = new Vector2();

	[Export]
	public int direction = 1;

	public void MoveDirection()
	{
		velocity = new Vector2();
		velocity.x += direction;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		MoveDirection();
		var collision = MoveAndCollide(velocity);

		if (collision != null)
		{
			// Colliding with the stage walls
			if (collision.Collider is StaticBody2D)
			{
				direction = -direction;
			}
		}
	}
}
