using UnityEngine;

public class CutScene : Camera_Movement
{
    [Header("CutScene Settings")]
    public GameObject Dialogue;
    public GameObject ButtonE;
    public GameObject Kolobok;
    public Vector3 targetPosition = new Vector3(41f, -12f, -10f);
    public float moveSpeed = 2f; // Скорость движения
    public float stayTime = 1f;  // Время задержки в секундах

    private enum CutsceneState { None, MovingToTarget, Staying, Returning }
    private CutsceneState currentState;
    private float stayTimer;
    private Vector3 originalPosition;
    private Vector3 newPosition;

    protected override void Start()
    {
        base.Awake();
        currentState = CutsceneState.None;
        updateEnabled = true;
    }

    void Update()
    {

        if (Kolobok!=null && ButtonE == null && !Dialogue.activeSelf && currentState == CutsceneState.None)
        {
            updateEnabled = false;
            Kolobok.SetActive(true);
            StartCutscene();
        }

        if (Kolobok != null && Kolobok.activeSelf)
        {
            newPosition = Kolobok.transform.position;
            newPosition.x += 3f * Time.deltaTime;
            Kolobok.transform.position = newPosition;
            if (Kolobok.transform.position.x >= 46)
                Destroy(Kolobok);
        }
        switch (currentState)
        {
            case CutsceneState.MovingToTarget:
                MoveToTarget();
                break;
                
            case CutsceneState.Staying:
                StayAtTarget();
                break;
                
            case CutsceneState.Returning:
                ReturnToPlayer();
                break;
                
            default:
                base.Update();
                break;
        }
    }

    private void StartCutscene()
    {
        isStop = true;
        originalPosition = transform.position;
        currentState = CutsceneState.MovingToTarget;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            currentState = CutsceneState.Staying;
            stayTimer = stayTime;
        }
    }

    private void StayAtTarget()
    {
        if (Kolobok == null)
        {
            currentState = CutsceneState.Returning;
        }
    }

    private void ReturnToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        
        // Проверка возврата
        if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
        {
            EndCutscene();
            
            
        }
    }

    private void EndCutscene()
    {
        currentState = CutsceneState.None;
        isStop = false;
        updateEnabled = true;
    }
}