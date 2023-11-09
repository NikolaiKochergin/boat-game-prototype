using System;

namespace Source.Scripts.UI.Elements
{
    [Serializable]
    public class UIRootComponentReference : ComponentReferenceByTutorial<UIRoot>
    {
        public UIRootComponentReference(string guid) : base(guid)
        {
        }
    }
}