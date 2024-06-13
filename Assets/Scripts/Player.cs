using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("Animations")]
    [field: HideInInspector] public PlayerAnimeData AnimeData { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerController Input { get; private set; }
    public CharacterController Controller { get; private set; }

    private void Awake()
    {
        AnimeData.Initialize();
        Animator = GetComponent<Animator>();
        Input = GetComponent<PlayerController>();
        Controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
