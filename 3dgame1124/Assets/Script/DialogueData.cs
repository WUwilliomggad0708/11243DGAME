using UnityEngine;

namespace xin
{ 
    /// <summary>
    /// 對話資料
    /// </summary>
    [CreateAssetMenu(menuName = "xin/Dialogue Data",fileName = "New Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("對話者名稱")]
        public string dialogueName;
        [Header("對話內容"),TextArea(2,5)]
        public string[] dialogueContents;

    }
}