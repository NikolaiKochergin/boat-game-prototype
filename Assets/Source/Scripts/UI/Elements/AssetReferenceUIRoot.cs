using System;

namespace Source.Scripts.UI.Elements
{
    [Serializable]
    public class AssetReferenceUIRoot : ComponentReferenceByTutorial<UIRoot>
    {
        public AssetReferenceUIRoot(string guid) : base(guid)
        {
        }
    }
}