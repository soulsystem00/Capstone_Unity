using UnityEngine;
# if PLATFORM_ANDROID
using UnityEngine.Android;
# endif

public class PermissionsRationaleDialog : MonoBehaviour
{
    const int kDialogWidth = 1200;
    const int kDialogHeight = 300;
    private bool windowOpen = true;

    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(10, 20, kDialogWidth - 20, kDialogHeight - 50), "Please let me use the microphone.");
        GUI.Button(new Rect(10, kDialogHeight - 70, 300, 60), "No");
        if (GUI.Button(new Rect(kDialogWidth - 320, kDialogHeight - 70, 300, 60), "Yes"))
        {
#if PLATFORM_ANDROID
            Permission.RequestUserPermission(Permission.Microphone);
#endif
            windowOpen = false;
            Debug.Log("Change");
            Debug.Log(Permission.HasUserAuthorizedPermission(Permission.Microphone));
        }
    }

    void OnGUI()
    {
        if (windowOpen)
        {
            Rect rect = new Rect((Screen.width / 2) - (kDialogWidth / 2), (Screen.height / 2) - (kDialogHeight / 2), kDialogWidth, kDialogHeight);
            GUI.ModalWindow(0, rect, DoMyWindow, "Permissions Request Dialog");
        }
    }
}