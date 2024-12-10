using UnityEngine;
using UnityEngine.UIElements;

public class bg_scroll : MonoBehaviour
{
    [SerializeField]
    float xMod = 0.0015f;
    [SerializeField]
    float yMod = 0.03f;
    
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime * yMod;
        offset.x = transform.position.x * xMod;
        mat.mainTextureOffset = offset;
    }
}
