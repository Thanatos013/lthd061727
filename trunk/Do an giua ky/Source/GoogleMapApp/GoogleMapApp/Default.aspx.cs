﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoogleMapApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            NguoiDungDTO nguoiDung = NguoiDungDAO.DangNhap(username, password);
            if (nguoiDung != null)
                Response.Redirect("index.aspx");
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            NguoiDungDTO nguoiDung = NguoiDungDAO.DangKy(username, password);
            if (nguoiDung != null)
                Response.Redirect("index.aspx");
        }
    }
}