using UnityEngine;
using UnityEngine.UI;

public class CompassMark : MonoBehaviour
{
    public Sprite Icon;
    public Image Image { get; set; }

    public Vector2 position
    {
        get { return new Vector2(transform.position.x, transform.position.z); }
    }
}