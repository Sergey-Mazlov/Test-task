using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Prop : MonoBehaviour, IInteractable
{
    public PropType type;
    public void OnInteract(InteractionManager interactionManager)
    {
        interactionManager.Grab(gameObject);
    }
}
public enum PropType
{
    Cube,
    Sphere,
    Capsule
}
