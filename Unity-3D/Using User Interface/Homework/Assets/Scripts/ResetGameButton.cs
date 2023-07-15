using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameButton : MonoBehaviour
{
   public void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
