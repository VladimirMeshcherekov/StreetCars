using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Gameplay
{
    public class RestartButton : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}