using UnityEngine;

public class CreateModel : MonoBehaviour
{

    public Transform parent;
    public Transform ground;

    public void Create(Transform model)
    {
        Instantiate(model.gameObject,
                    Vector3.zero,                  
                    model.rotation,
                    parent);
    }
}
