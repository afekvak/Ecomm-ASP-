﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm
{
    public partial class static_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Product tmp = Product.GetById(1);
        }
    }
}