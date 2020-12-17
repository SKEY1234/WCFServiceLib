using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceLib
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(string value);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Pass { get; set; }
        
        [DataMember]
        public bool Exists { get; set; }
    }
}
