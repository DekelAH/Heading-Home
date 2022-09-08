

namespace Assets.Scripts.StorageSystem
{
    public abstract class StorageSystem
    {
        #region Methods

        public void Load()
        {
            LoadInternal();
        }

        protected abstract void LoadInternal();

        public void Save()
        {
            SaveInternal();
        }

        protected abstract void SaveInternal();

        #endregion
    }
}
