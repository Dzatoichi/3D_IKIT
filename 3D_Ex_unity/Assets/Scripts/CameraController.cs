using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Настройки вращения")]
    [Tooltip("Скорость вращения камеры")]
    public float rotationSpeed = 5f;
    
    [Tooltip("Ограничение по вертикали (в градусах)")]
    public float verticalClamp = 80f;

    private Vector2 rotation = Vector2.zero;
    private bool isRotating = false;

    void Update()
    {
        // Начало вращения при нажатии ЛКМ
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Окончание вращения при отпускании ЛКМ
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Вращение камеры при зажатой ЛКМ
        if (isRotating)
        {
            // Получаем ввод мыши
            rotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
            rotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;
            
            // Ограничиваем вертикальное вращение
            rotation.y = Mathf.Clamp(rotation.y, -verticalClamp, verticalClamp);
            
            // Применяем вращение
            transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
        }
    }
}