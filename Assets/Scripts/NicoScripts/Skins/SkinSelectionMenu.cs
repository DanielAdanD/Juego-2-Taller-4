// File: SkinSelectionMenu.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelectionMenu : MonoBehaviour
{
    // Este m�todo ser� llamado por los botones de la UI
    public void SelectSkin(int skinIndex)
    {
        if (SkinManager.Instance != null)
        {
            // Asignar el �ndice de la skin seleccionada
            SkinManager.Instance.selectedSkinIndex = skinIndex;

            // Cargar la escena del juego (ej. "GameScene")
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.LogError("SkinManager no encontrado. Aseg�rate de que SkinManager est� presente en la escena.");
        }
    }
}
