using System;
using System.Runtime.Serialization;

namespace WcfServices.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }
    }
}
