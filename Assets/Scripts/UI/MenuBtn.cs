using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuBtn : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoveredSprite;

    private Button button;
    private bool isHovered = false;
    private Vector3 originalScale;

    void Start()
    {
        button = GetComponent<Button>();
        button.image.sprite = normalSprite;
        originalScale = transform.localScale;
    }
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        EventSystem eventSystem = EventSystem.current;
        if (IsMouseOver())
        {
            if (!isHovered)
            {
                button.image.sprite = hoveredSprite;
                isHovered = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                transform.localScale = originalScale * 0.9f;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //this.button.GetComponent<Button>().onClick.Invoke();
            }
        }
        else
        {
            if (isHovered)
            {
                button.image.sprite = normalSprite;
                isHovered = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = originalScale;
        }
    }
    public void ScaleReset()
    {
        transform.localScale = originalScale;
    }
    bool IsMouseOver()
    {
        RectTransform rt = button.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rt, Input.mousePosition);
    }
}
