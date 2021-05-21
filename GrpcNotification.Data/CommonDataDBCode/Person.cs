using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace GrpcNotification.Data
{

    public partial class Person
    {
        public Person(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
