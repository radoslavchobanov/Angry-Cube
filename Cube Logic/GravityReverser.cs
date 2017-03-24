using UnityEngine;
using System.Collections;

public class GravityReverser : MonoBehaviour 
{
	public static void GravityReverse()
	{
		Physics2D.gravity = new Vector2 (0, -10);
	}

	public static void NormalGravity()
	{
		Physics2D.gravity = new Vector2 (0, 10);
	}
}
