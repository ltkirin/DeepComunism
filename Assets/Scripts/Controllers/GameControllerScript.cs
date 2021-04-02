using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers 
{
	public class GameControllerScript : MonoBehaviour
	{
		private void Start()
		{
			foreach (var controller in ControllersManager.StartControllers)
			{
				controller.Start();
			}
		}

		private void FixedUpdate()
		{
			foreach (var controller in ControllersManager.FixedUpdateControllers)
			{
				controller.FixedUpdate();
			}
		}

		private void Update()
		{
			foreach (var controller in ControllersManager.UpdateControllers)
			{
				controller.Update();
			}
		}

		private void LateUpdate()
		{
			foreach (var controller in ControllersManager.LateUpdateControllers)
			{
				controller.LateUpdate();
			}
		}
	}
}
