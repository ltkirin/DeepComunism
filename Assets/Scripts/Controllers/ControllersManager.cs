using Assets.Scripts.Interfaces;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers
{
	public static class ControllersManager
	{
		private static readonly IList<IStartController> startControllers;
		private static readonly IList<IFixedUpdateController> fixedUpdateControllers;
		private static readonly IList<IUpdateController> updateControllers;
		private static readonly IList<ILateUpdateController> lateUpdateControllers;

		static ControllersManager()
		{
			startControllers = new List<IStartController>();
			fixedUpdateControllers = new List<IFixedUpdateController>();
			updateControllers = new List<IUpdateController>();
			lateUpdateControllers = new List<ILateUpdateController>();
		}

		public static IList<IStartController> StartControllers => startControllers;

		public static IList<IFixedUpdateController> FixedUpdateControllers => fixedUpdateControllers;

		public static IList<IUpdateController> UpdateControllers => updateControllers;

		public static IList<ILateUpdateController> LateUpdateControllers => lateUpdateControllers;

		public static void RegisterController<TController>(TController controller) where TController : ControllerBase
		{
			if(controller is IStartController start)
			{
				startControllers.Add(start);
			}
			if(controller is IFixedUpdateController fixedUpdate)
			{
				fixedUpdateControllers.Add(fixedUpdate);
			}
			if(controller is IUpdateController update)
			{
				updateControllers.Add(update);
			}
			if (controller is ILateUpdateController lateUpdate)
			{
				lateUpdateControllers.Add(lateUpdate);
			}
		}

	}
}
