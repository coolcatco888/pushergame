using Godot;
using System;

public class RollieBall : KinematicBody
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

    private Vector3 velocity = new Vector3();

    private MeshInstance meshInstance = new MeshInstance();

    private const int speed = 5;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        this.meshInstance = this.GetNode<MeshInstance>("MeshInstance");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {

        if (Input.IsActionPressed("ui_right") && Input.IsActionPressed("ui_left")) 
        {
            velocity.x = 0;
        } 
        else if (Input.IsActionPressed("ui_right")) 
        {
            velocity.x = speed;
            this.meshInstance.RotateZ(ConvertDegreesToRadians(-speed));
        } 
        else if (Input.IsActionPressed("ui_left")) 
        {
            velocity.x = -speed;
            this.meshInstance.RotateZ(ConvertDegreesToRadians(speed));
        }
        else 
        {
            velocity.x = Mathf.Lerp(velocity.x, 0, 0.1f);
        }

        if (Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_down")) 
        {
            velocity.z = 0;
        } 
        else if (Input.IsActionPressed("ui_up")) 
        {
            velocity.z = -speed;
            this.meshInstance.RotateX(ConvertDegreesToRadians(-speed));
        } 
        else if (Input.IsActionPressed("ui_down")) 
        {
            velocity.z = speed;
            this.meshInstance.RotateX(ConvertDegreesToRadians(speed));
        }
        else 
        {
            velocity.z = Mathf.Lerp(velocity.z, 0, 0.1f);
        }

        if (Input.IsActionPressed("ui_select")) 
        {
            velocity.y = speed;
        }
        else 
        {
            velocity.y = Mathf.Lerp(velocity.y, -speed, 0.1f);
        }

        this.MoveAndSlide(velocity);
    }

    private static float ConvertDegreesToRadians(float degrees)
    {
        float radians = ((float)Math.PI / 180) * degrees;
        return radians;
    }
}
