using Assets.Scripts.Controllers;
using Assets.Scripts.Enums;
using Assets.Scripts.Interaction;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

public class RoadInteraction : InteractionBase<RoadTileController>, ITilePriamryInteraction
{
    public RoadInteraction(RoadTileController controller) : base(controller)
    {
    }


    private IAddonInteraction addonInteraction;

    public IEnumerator ExecuteInteraction(IInteractableCharacter target)
    {
        target.CurrentInteraction = this;
        if (addonInteraction != null)
        {
        }
        target.SetVelocity(controller.MovingVelocity);
        while (target.CurrentInteraction == this)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    public void SetAddon(TileAddon addon)
    {
        if (addonInteraction == null)
        {
            switch (addon)
            {
                case (TileAddon.DirectionSwitch):
                    addonInteraction = new DirectionSwitchInteraction(this);
                    break;
                case (TileAddon.DisabledRoad):
                    addonInteraction = new DisabledRoadInteraction(this);
                    break;
                case (TileAddon.Obstacle):
                    addonInteraction = new ObstacleInteraction(this);
                    break;    
                case (TileAddon.Spawner):
                    addonInteraction = new SpawnerInteraction(this);
                    break;
                case (TileAddon.None):
                    addonInteraction = null;
                    break;
            }
        }
    }
}
