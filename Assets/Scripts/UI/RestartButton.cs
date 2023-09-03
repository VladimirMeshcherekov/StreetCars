using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartButton : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}