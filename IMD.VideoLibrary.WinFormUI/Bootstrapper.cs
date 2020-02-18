using IMD.VideoLibrary.BusinessLogic;
using IMD.VideoLibrary.Repository;
using IMD.VideoLibrary.ViewModel;


using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.WinFormUI
{
    /// <summary>
    /// Boot strapper class
    /// </summary>
    public class Bootstrapper
    {
        private readonly IUnityContainer _container;

        public Bootstrapper()
        {
            this._container = new UnityContainer();
        }

        public IUnityContainer Run()
        {
            this._container.AddNewExtension<BusinessLogicUnityExtension>();
            this._container.AddNewExtension<RepositoryUnityExtension>();
            this._container.AddNewExtension<WinFormUIUnityExtension>();
            this._container.AddNewExtension<ViewModelUnityExtension>();

            return this._container;
        }
    }
}
