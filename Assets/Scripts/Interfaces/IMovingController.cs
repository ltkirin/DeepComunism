using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interfaces 
{
	public interface IMovingObjectController 
	{
		float MaxVelocity { get; set; }
		float currentVelocity { get; set; }
	}
}
