using System;
using Google.Protobuf.WellKnownTypes;

namespace GrpcNotification.Common.Model
{
    public class GrpcContent
    {
        public Type LockType { get; set; }
        public int Oid { get; set; }
        public Timestamp LockTime { get; set; } = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime());
        public Boolean IsLock { get; set; }
        public enum Type
        {
            PERSON,
            ENTITY
        }
    }
}