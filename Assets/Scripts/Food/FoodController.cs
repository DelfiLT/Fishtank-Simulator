using UnityEngine;

public class FoodController : MonoBehaviour
{
    float newGravity = -0.7f; //queria ponerle serializefield pero por alguna razon eso lo rompe???

    void Start()
    {
        Physics.gravity = new Vector3(0, newGravity, 0);
    }
}
