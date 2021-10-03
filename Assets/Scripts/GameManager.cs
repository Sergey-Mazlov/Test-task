using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private Text resultCubeCountText;
    [SerializeField] private Text resultSphereCountText;
    [SerializeField] private Text resultCapsuleCountText;
    [SerializeField] private Text cubeCountText;
    [SerializeField] private Text sphereCountText;
    [SerializeField] private Text capsuleCountText;
    [SerializeField] private Transform props;
    [SerializeField] private StarterAssetsInputs inputs;

    private int _cubeCount;
    private int _sphereCount;
    private int _capsuleCount;
    
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public void AddProp(PropType type)
    {
        switch (type)
        {
            case PropType.Cube:
                _cubeCount++;
                cubeCountText.text = _cubeCount.ToString();
                break;
            case PropType.Sphere:
                _sphereCount++;
                sphereCountText.text = _sphereCount.ToString();
                break;
            case PropType.Capsule:
                _capsuleCount++;
                capsuleCountText.text = _capsuleCount.ToString();
                break;
        }
        CheckWin();
    }

    private void CheckWin()
    {
        if (props.childCount == 0)
        {
            resultPanel.SetActive(true);
            resultCubeCountText.text = _cubeCount.ToString();
            resultSphereCountText.text = _sphereCount.ToString();
            resultCapsuleCountText.text = _capsuleCount.ToString();
            inputs.ShowCursor();
        }
    }
    
}
