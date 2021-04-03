using UnityEngine;

namespace Assets.Scripts.Components
{
	public class TileComponent : ComponentBase
	{
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		private void Awake()
		{
			spriteRenderer = transform.GetComponent<SpriteRenderer>();
			spriteRenderer.enabled = false;
		}

		public override void Activate()
		{
			spriteRenderer.enabled = true;
			base.Activate();
		}

		public override void Deactivate()
		{
			spriteRenderer.enabled = false;
			base.Deactivate();
		}

		public void SetSprite(Sprite sprite)
		{
			spriteRenderer.sprite = sprite;
		}
	}
}
