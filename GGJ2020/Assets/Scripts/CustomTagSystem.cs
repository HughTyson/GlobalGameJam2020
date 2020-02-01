using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTagSystem : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<TAG> tags;
    public enum TAG
    { 
        WIRE_SOCKET,
        WIRE_PLUG,
        INTERACTIVE,
        HUGH_BUTTON,
        DAN_BUTTON,
        LEVER,
        FINAL_BUTTON
    }


    public bool ContainsTag(TAG tag)
    {
        return tags.Contains(tag);
    }

    public List<TAG> GetTags()
    {
        return tags;
    }
}
