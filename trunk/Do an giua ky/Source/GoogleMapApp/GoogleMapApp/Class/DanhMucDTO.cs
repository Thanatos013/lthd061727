﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleMapApp
{
    public class DanhMucDTO
    {
        private string tenDanhMuc;
        NguoiDungDTO nguoiDung;

        public string TenDanhMuc
        {
            get { return tenDanhMuc; }
            set { tenDanhMuc = value; }
        }
        public NguoiDungDTO NguoiDung
        {
            get { return nguoiDung; }
            set { nguoiDung = value; }
        }
    }
}