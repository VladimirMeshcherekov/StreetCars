using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Menu
{
    public class RunGameButton : MonoBehaviour
    {
        public void RunGame()
        {
            SceneManager.LoadScene("Scenes/Gameplay");
        }
    }
}
