using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MoleWhacker : MonoBehaviour
{

    [SerializeField] Camera camera;
    [SerializeField] int pointsPerMole;
    [SerializeField] ScoreManager scoreManager;

    int playerScoredNum = 1;
    float touchYPosition = 0f;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }


    private void Update()
    {
        foreach (Touch t in Touch.activeTouches)
        {
            if (t.began)
            {
                DebugDrawTouch(Camera.main.ScreenToWorldPoint((Vector3)t.screenPosition + Vector3.forward * 10));

                Ray ray = Camera.main.ScreenPointToRay(t.screenPosition);

                ProcessWhack(ray);
            }
        }

        if (Mouse.current.leftButton.isPressed)
        {
            DebugDrawTouch(Camera.main.ScreenToWorldPoint((Vector3)Mouse.current.position.value + Vector3.forward * 10));

            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);

            ProcessWhack(ray);
        }


    }

    private void ProcessWhack(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Mole"))
            {
                Destroy(hit.collider.gameObject);

                touchYPosition = camera.WorldToScreenPoint(hit.transform.position).y / Screen.height;
                playerScoredNum = touchYPosition >= 0.5f ? 2 : 1;

                scoreManager.IncrementPlayerPoints(pointsPerMole, playerScoredNum);
            }
        }
    }

    private static void DebugDrawTouch(Vector3 touchWorldPosition)
    {
        Vector3 worldPosition = touchWorldPosition;

        Debug.DrawLine(worldPosition + Vector3.up, worldPosition + Vector3.down, Color.red, 10f);
        Debug.DrawLine(worldPosition + Vector3.left, worldPosition + Vector3.right, Color.red, 10f);
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

}
