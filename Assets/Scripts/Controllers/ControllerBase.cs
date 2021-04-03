using Assets.Scripts.Enums;

namespace Assets.Scripts.Controllers
{
	public abstract class ControllerBase
	{
		public bool IsActive { get; set; }
		public ControllerState State { get => state; set => state = value; }

		private ControllerState state = ControllerState.Inactive;
		public ControllerBase()
		{
			state = ControllerState.Loading;
			ControllersManager.RegisterController(this);
		}
	}
}
