namespace Assets.Scripts.Controllers
{
	public abstract class ControllerBase
	{
		public ControllerBase()
		{
			ControllersManager.RegisterController(this);
		}
	}
}
