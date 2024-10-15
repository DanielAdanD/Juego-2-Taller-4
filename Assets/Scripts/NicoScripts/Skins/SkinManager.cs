// File: SkinManager.cs
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public ElInt indiceSkin;
    public static SkinManager Instance;

    // 0 = base, 1 = variante 1, 2 = variante 2
    public int selectedSkinIndex = 0;

    private void Awake()
    {
        // Asegurar que solo hay una instancia del SkinManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir este objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        indiceSkin.value = selectedSkinIndex;
    }
}
