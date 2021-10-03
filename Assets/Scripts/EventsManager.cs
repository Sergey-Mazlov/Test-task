using UnityEngine;
using UnityEngine.SceneManagement;

public class EventsManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Playground");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
