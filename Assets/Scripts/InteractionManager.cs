using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private Transform itemContainer;
    [SerializeField] private Transform propsHolder;
    
    public GameObject Prop { get; private set; }
    
    private Camera _mainCamera;
    private StarterAssetsInputs _input;
    private bool _isEquipped = false;
    private Rigidbody _propRb;
    private void Awake()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }
    }

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void FixedUpdate()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactText.SetActive(true);
                if (_input.interact)
                {
                    Debug.Log(interactable);
                    interactable.OnInteract(this);
                    _input.interact = false;
                }
            }
        }
        else if (_isEquipped && _input.interact)
        {
            Drop();
            _input.interact = false;
        }
        else
        {
            interactText.SetActive(false);
            _input.interact = false;
        }

        if (Prop)
        {
            Vector3 dir = itemContainer.position - Prop.transform.position;
            _propRb.velocity = dir;
        }
    }

    public void Grab(GameObject prop)
    {
        if (_isEquipped)
        {
            Drop();
        }
        Prop = prop;
        _isEquipped = true;
        
        _propRb = Prop.GetComponent<Rigidbody>();
        _propRb.useGravity = false;
        _propRb.freezeRotation = true;
        
        Prop.transform.SetParent(itemContainer);
        Prop.layer = 2;
    }

    private void Drop()
    {
        _isEquipped = false;
        
        _propRb.useGravity = true;
        _propRb.freezeRotation = false;
        
        Prop.transform.SetParent(propsHolder);
        Prop.layer = 6;
        Prop = null;
    }

    public void GiveAway()
    {
        _isEquipped = false;
        Destroy(Prop);
    }
}
