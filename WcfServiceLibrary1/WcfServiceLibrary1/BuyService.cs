﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BuyService" in both code and config file together.
    public class BuyService : IBuyService
    {
        DBConnect con = DBConnect.DB_INSTANCE;
        public bool BuyItem(int user_id, int item_id)//if this one is called, also call the refresh and GetUserInventoryServices to reset both fields
        {
            return con.BuyItem(user_id, item_id);
        }
    }
}
