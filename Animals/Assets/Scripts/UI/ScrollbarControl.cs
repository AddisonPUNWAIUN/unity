using UnityEngine;
using UnityEngine.UI;

public class ScrollbarControl : MonoBehaviour
{
    Scrollbar scrollbar;
    float scrollRange ;
    void Start()
    {
        scrollbar = transform.Find("Scrollbar").GetComponent<Scrollbar>();
        scrollRange = GetComponent<RectTransform>().rect.width;
        //scrollbar.size = 1+scrollRange / (3 * 200);
    }
    public void LeftToRight(RectTransform list)
    {
        list.localPosition = new Vector3(scrollbar.value * -scrollRange, list.localPosition.y, list.localPosition.z);
    }
    public void RightToLeft(RectTransform list)
    {
        list.localPosition = new Vector3(scrollbar.value * scrollRange, list.localPosition.y, list.localPosition.z);
    }
    public void TopToBottom(RectTransform list)
    {
        list.localPosition = new Vector3(list.localPosition.x, scrollbar.value * scrollRange, list.localPosition.z);
    }
    public void BottomToUp(RectTransform list)
    {
        list.localPosition = new Vector3(list.localPosition.x, scrollbar.value * -scrollRange, list.localPosition.z);
    }

}
