using UnityEngine;
public class Receiver : MonoBehaviour, IInteractable
{
    public PropType type;
    public void OnInteract(InteractionManager interactionManager)
    {
        if(!interactionManager.Prop) return;
        Prop prop = interactionManager.Prop.GetComponent<Prop>();
        if (prop.type == type)
        {
            interactionManager.GiveAway();
            GameManager.Instance.AddProp(type);
        }
    } 
}
