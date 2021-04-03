using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileInteraction
{
    IEnumerator ExecuteInteraction(IInteractableCharacter target);
}
