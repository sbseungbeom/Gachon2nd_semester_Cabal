using UnityEngine;
using UnityEngine.UI;

public class TransparentButtonManager : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite hoveredSprite;

    private Button[] buttons;
    private int lastHoveredButtonIndex = -1;

    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.GetComponent<Image>().sprite = normalSprite;
        }
    }

    void Update()
    {
        int hoveredButtonIndex = -1;

        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform rt = buttons[i].GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(rt, Input.mousePosition))
            {
                hoveredButtonIndex = i;
            }
        }

        if (hoveredButtonIndex != lastHoveredButtonIndex)
        {
            if (lastHoveredButtonIndex != -1)
            {
                buttons[lastHoveredButtonIndex].GetComponent<Image>().sprite = normalSprite;
            }

            if (hoveredButtonIndex != -1)
            {
                buttons[hoveredButtonIndex].GetComponent<Image>().sprite = hoveredSprite;
            }

            lastHoveredButtonIndex = hoveredButtonIndex;
        }
    }
}
