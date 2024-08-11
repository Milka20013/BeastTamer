using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EntityContainer entityContainer;

    private void Start()
    {
        entityContainer.LoadEntites();
    }
}
