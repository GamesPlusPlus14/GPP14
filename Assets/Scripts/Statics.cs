using UnityEngine;

public class Statics : MonoBehaviour
{
    public static readonly string PHorz = "PlayerHorizontal";
    public static readonly string PVert = "PlayerVertical";

    public static readonly string WHorz = "WindowHorizontal";
    public static readonly string WVert = "WindowVertical";

    public static readonly string WHorz1 = "WindowHorizontal1";
    public static readonly string WVert1 = "WindowVertical1";

    public static readonly string AButton = "AButton";

    public static readonly string ViewWindow = "ViewWindow";
	public static readonly string InventoryManager = "InventoryManager";
    public static readonly string Projectile = "Projectile";

    public static bool onePlayer { get; set;}
    public static bool gamePaused { get; set; }
    public static float heightInUnity { get; set; }
    public static float widthInUnity { get; set; }
    public static bool playerIsDead { get; set; }
    public static float currentLevel = 1;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        heightInUnity = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y - Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        widthInUnity = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x - Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }
}
