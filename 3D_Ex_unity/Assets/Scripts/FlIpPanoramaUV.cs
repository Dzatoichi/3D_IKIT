using UnityEngine;

public class FlipPanoramaUV : MonoBehaviour
{
    void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.mainTextureScale = new Vector2(-1, 1); // Отразить по X
        material.mainTextureOffset = new Vector2(1, 0); // Сместить, чтобы не было разрыва
    }
}