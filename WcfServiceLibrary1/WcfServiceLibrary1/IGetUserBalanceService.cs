﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetUserBalanceService" in both code and config file together.
    [ServiceContract]
    public interface IGetUserBalanceService
    {
        [OperationContract]
        float GetBalance(int user_id);
    }
}
