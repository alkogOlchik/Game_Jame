using UnityEngine;
using System.Collections;
public class ObjectGlitchController : MonoBehaviour
{
    public Material glitchMaterial; // Перетащите сюда ваш материал
    private Material originalMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
    }

    // Включить глитч
    public void EnableGlitch()
    {
        objectRenderer.material = glitchMaterial;
    }

    // Выключить глитч
    public void DisableGlitch()
    {
        objectRenderer.material = originalMaterial;
    }

    // Пример: мигающий глитч
    IEnumerator RandomGlitch()
    {
        while (true)
        {
            if (Random.value > 0.5f)
            {
                EnableGlitch();
                yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
                DisableGlitch();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}