using System.ComponentModel.DataAnnotations;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpo;
using GrpcNotification.Data;
using GrpcNotification.Common;

namespace GrpcNotification.Client.WpfDx.ViewModels
{
    [MetadataType(typeof(MetaData))]
    public class MainViewModel
    {
        public class MetaData : IMetadataProvider<MainViewModel>
        {
            void IMetadataProvider<MainViewModel>.BuildMetadata
                (MetadataBuilder<MainViewModel> p_builder)
            {
            }
        }

        #region Constructors

        protected MainViewModel()
        {
        }

        public static MainViewModel Create()
        {
            return ViewModelSource.Create(() => new MainViewModel());
        }

        #endregion

        #region Fields and Properties

        
        public virtual UnitOfWork unitOfWork { get; set; }
        public virtual XPCollection<Person> PersonCollection { get; set; }
        public virtual Person SelectedPerson { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}