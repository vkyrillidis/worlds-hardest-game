using Godot;
using System;
using System.Xml.Schema;

public class Main : Node2D
{
	public int deaths = 0;

	private void _on_Player_GameWon()
	{
		// Stop all from moving and show congratulatory message
		GetNode<Player>("Player").Hide();
		GetNode<Label>("GameWonLabel").Visible = true;
		GetNode<AudioStreamPlayer>("BackgroundMusic").Stop();
	}

	private void _on_Player_PlayerDied()
	{
		deaths++;
		GetNode<Label>("DeathsCountLabel").Text = $"Deaths: {deaths}";
	}
}
