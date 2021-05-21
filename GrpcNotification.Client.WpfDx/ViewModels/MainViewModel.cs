using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Windows.Data;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Google.Protobuf.WellKnownTypes;
using GrpcNotification.Data;
using GrpcNotification.Common;
using GrpcNotification.Common.Client;
using GrpcNotification.Common.Model;
using Newtonsoft.Json;

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
                p_builder.CommandFromMethod(p_x => p_x.OnLockPersonScriptCommand()).CommandName("LockPersonScriptCommand");
                p_builder.CommandFromMethod(p_x => p_x.OnUpdatePersonScriptCommand()).CommandName("UpdatePersonScriptCommand");
                p_builder.Property(p_x => p_x.SelectedPerson).OnPropertyChangedCall(p_x => p_x.OnSelectedPersonChanged());
            }
        }

        #region Constructors

        protected MainViewModel()
        {
            unitOfWork = new UnitOfWork()
            {
                ConnectionString = "XpoProvider=MSSqlServer;data source=(localdb)\\MSSQLLocalDB;integrated security=SSPI;initial catalog=SampleData",
                AutoCreateOption = AutoCreateOption.DatabaseAndSchema
            };
            PersonCollection = new XPCollection<Person>(unitOfWork);


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


        private void StartReadingNotificationServer()
        {

        }

        public void OnUpdatePersonScriptCommand()
        {
            
        }
        public void OnLockPersonScriptCommand()
        {
            SelectedPerson.IsLocked = !SelectedPerson.IsLocked;
            unitOfWork.CommitChanges();

            var content = JsonConvert.SerializeObject(new GrpcContent()
            {
                IsLock = SelectedPerson.IsLocked,
                LockTime = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
                LockType = GrpcContent.Type.PERSON
            });


 
            
        }

        public void OnSelectedPersonChanged()
        {
            
        }
        #endregion
    }
}