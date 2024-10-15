// File: SkinSelectionMenu.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelectionMenu : MonoBehaviour
{
    // Este método será llamado por los botones de la UI
    public void SelectSkin(int skinIndex)
    {
        if (SkinManager.Instance != null)
        {
            // Asignar el índice de la skin seleccionada
            SkinManager.Instance.selectedSkinIndex = skinIndex;

            // Cargar la escena del juego (ej. "GameScene")
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.LogError("SkinManager no encontrado. Asegúrate de que SkinManager está presente en la escena.");
        }
    }
}
