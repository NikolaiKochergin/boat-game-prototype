using System;

namespace Source.Scripts.UI.Windows
{
    [Serializable]
    public class WindowBaseComponentReference : ComponentReference<WindowBase>
    {
        public WindowBaseComponentReference(string guid) : base(guid)
        {
        }
    }
}