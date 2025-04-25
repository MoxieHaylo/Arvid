using UnityEngine;

public class GameAssets : MonoBehaviour
{
    static GameAssets instance;

    public static GameAssets i
    {
        get
        {
            if (instance == null) instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
        }
    }

    public Transform prefabTextBubble;
}
