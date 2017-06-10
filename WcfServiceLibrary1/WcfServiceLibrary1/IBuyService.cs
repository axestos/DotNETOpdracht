using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBuyService" in both code and config file together.
    [ServiceContract]
    public interface IBuyService
    {
        [OperationContract]
        bool BuyItem(string username, string item_name);//if this one is called, also call the refresh and GetUserInventoryServices to reset both fields
    }
}
