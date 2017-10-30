using UnityEngine;
using UnityEngine.UI; 

public class Canvas : MonoBehaviour
{

    static Canvas _canvas;
    void Start()
    {
        _canvas = this;
    }

    public static Transform GetCanvas()
    { return _canvas.transform; }
    /// 表示・非表示を設定する
    /// 
    public static GetPost GetLoadingObject()
    {
        return _canvas.transform.GetComponent<GetPost>();
    }

    public static void SetTextUI(string Tname, string text)
    {
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == Tname)
            {
                // 指定した名前と一致
                Text target = child.gameObject.GetComponent<Text>();
                target.text = text;
                // おしまい
                return;
            }
        }
        Debug.LogWarning("Not found objname:" + Tname);
    }
    public static Transform getObject(string Tname)
    {

        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == Tname)
            {
                // 指定した名前と一致
                // おしまい
                return child;
            }
        }
        Debug.LogWarning("Not found objname:" + Tname);
        return null;
    }
    public static void SetActive(string name, bool b)
    {
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == name)
            {
                // 指定した名前と一致
                // 表示フラグを設定
                child.gameObject.SetActive(b);
                // おしまい
                return;
            }
        }
        // 指定したオブジェクト名が見つからなかった
        Debug.LogWarning("Not found objname:" + name);
    }

    public static void addLocationY(string name, int add)
    {
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == name)
            {
                Vector3 locate = child.localPosition;
                locate.y += add;
                child.localPosition = locate;
                // おしまい
                return;
            }
        }
        Debug.LogWarning("Not found objname:" + name);
    }
    public static void addLocationX(string name, int add)
    {
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == name)
            {
                Vector3 locate = child.localPosition;
                locate.x += add;
                child.localPosition = locate;
                // おしまい
                return;
            }
        }
        Debug.LogWarning("Not found objname:" + name);
    }
}
   