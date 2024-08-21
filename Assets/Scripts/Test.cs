using UnityEngine;

public class Test : MonoBehaviour
{
    public void OnAnimationEnd(string name)
    {
        Debug.Log("Animation ended " + name);
    }
    public void OnAnimationStart(string name)
    {
        Debug.Log("Animation started " + name);
    }
}
