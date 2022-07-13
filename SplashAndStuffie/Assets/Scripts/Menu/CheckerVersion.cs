using System.Globalization;
using System.Net;
using UnityEngine;
using System.Linq;
public class CheckerVersion : MonoBehaviour
{
    [SerializeField] private float _version;
    private float _currentVersion;
    private int _index;
    [SerializeField] private GameObject _blockPanel;
    [SerializeField] private GameObject _removedGroup;
    private bool _isRightVersion = true;

    public bool IsRightVersion { get => _isRightVersion; set => _isRightVersion = value; }

    private void OnEnable() 
    {
          ChangeText();
    }
    public void OpenURL()
    {
        Debug.Log("OPEN URL!!!");
        Application.OpenURL("https://prismatik.itch.io/splash-and-stuffie?secret=FLBigVDul6ypYerjt0RnahSTlg");
    }
    private void ChangeText()
    {
        WebClient webClient = new WebClient();
        string path = "https://vk.com/public212566133";
        string  html= webClient.DownloadString(path);
        Debug.Log(html);
        foreach (var item in html)
        {
            if (item == 'В')
            {
                _index =html.IndexOf(item);
            }
        }
        string vers ="";
        string partOfHtml = html.Remove(0,_index);
        Debug.Log(partOfHtml);
        int count = partOfHtml.FirstOrDefault(e=> e == 'S');
        Debug.Log((count + _index) + ": _= =as place");
        for (int i = 0; i < 13; i++)
        {
            vers += html[_index + i];
        }
        int index = vers.IndexOf(':');
        Debug.Log(index + " INDEX");
        string vers2 = vers.Remove(0,index + 2);
        Debug.Log(vers2 + "NUMBERS ONLY");
        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
ci.NumberFormat.CurrencyDecimalSeparator = ".";
double result = double.Parse(vers2,NumberStyles.Any,ci);
        _version = (float) result;
        double currentVersion = double.Parse(Application.version,NumberStyles.Any,ci);
        _currentVersion = (float) currentVersion;
        if (_currentVersion < _version)
        {
            Debug.Log("DOWNLOAD A NEW VERSION!");
            _blockPanel.SetActive(true);
            _removedGroup.SetActive(false);
            _isRightVersion = false;
        }
        else
        {
            if (_blockPanel.gameObject.activeInHierarchy)
            {
                _removedGroup.SetActive(true);
                _blockPanel.SetActive(false);
                _isRightVersion = true;
            }
        }
    }
}
