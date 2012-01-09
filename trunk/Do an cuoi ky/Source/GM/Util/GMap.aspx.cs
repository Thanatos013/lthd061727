﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Configuration;
using CaroSocialNetwork.DAO;

namespace CaroSocialNetwork
{
    public partial class GMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Map";

            LoadMyTreeView();
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript: initialize(); ", true);
        }

        public class CategoryTemp
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private Guid _id;
            public Guid Id
            {
                get { return _id; }
                set { _id = value; }
            }
        }

        [System.Web.Services.WebMethod]
        public static List<CategoryTemp> GetCategories()
        {
            List<LocationCategory> lc = LocationCategoryDAO.GetAll(Membership.GetUser());
            List<CategoryTemp> tempList = new List<CategoryTemp>();
            foreach (LocationCategory category in lc)
            {
                CategoryTemp temp = new CategoryTemp();
                temp.Name = category.Name;
                temp.Id = category.CategoryID;
                tempList.Add(temp);
            }
            return tempList;
        }       

        //protected void btnAddCategory_Click(object sender, EventArgs e)
        //{
        //    LocationCategory category = new LocationCategory();
        //    category.Name = txtCategoryName.Text;
        //    category.Deleted = false;
        //    category.UserID = (Guid)Membership.GetUser().ProviderUserKey;
        //    LocationCategoryDAO.AddCategory(category);
        //}

        public void LoadMyTreeView()
        {
            MembershipUser user = Membership.GetUser();
            //treeView.Nodes.Clear();
            List<LocationCategory> categories = LocationCategoryDAO.GetAll(user);

            for (int i = 0; i < categories.Count; ++i)
            {
                LocationCategory category = categories[i];
                Label l = new Label();
                l.ID = "DM" + category.CategoryID.ToString();

                //CayDiaDiem.Controls.Add(l);

                Literal li = new Literal();
                //li.Text = "<br/>";
                li.Text = "<strong>" + category.Name.ToString() + "</strong><br/>";
                l.Controls.Add(li);
                //CayDiaDiem.Controls.Add(li);

                for (int j = 0; j < category.Locations.Count; ++j)
                {
                    Location location = category.Locations[j];
                    if (location.Deleted == false)
                    {
                        /*Literal l1 = new Literal();
                        l1.Text = "&nbsp&nbsp+&nbsp";
                        CayDiaDiem.Controls.Add(l1);*/

                        HyperLink a = new HyperLink();
                        a.ID = "DD" + location.LocationID.ToString();
                        a.Text = /*"&nbsp&nbsp+&nbsp" + */location.Name.ToString() + "<br/>";
                        a.NavigateUrl = "javascript:(findMyLocation('"
                            + location.LocationID.ToString()
                            + "', '" + location.Name.ToString() + "', '"
                            + location.Note.ToString() + "'))";
                        l.Controls.Add(a);
                    }
                    //CayDiaDiem.Controls.Add(a);

                    /*Literal l2 = new Literal();
                    l2.Text = "<br/>";
                    CayDiaDiem.Controls.Add(l2);*/
                }
                //l.Text = "<strong>" + nguoiDungNode.ChildNodes[i].Attributes["tendanhmuc"].Value + "</strong><br/>";
                CayDiaDiem.Controls.Add(l);
            }
        }

        [System.Web.Services.WebMethod]
        public static int ThemDiaDiem(string tenDiaDiem, float viDo, float kinhDo, string ghiChu, int maDanhMuc, string tenDanhMuc)
        {
            try
            {
                //Thêm danh mục nếu chưa có, lấy ID của danh mục
                LocationCategory category = LocationCategoryDAO.FindCategory(tenDanhMuc, Membership.GetUser());
                if (category == null)
                {
                    category = new LocationCategory();
                    category.Name = tenDanhMuc;
                    category.UserID = (Guid)Membership.GetUser().ProviderUserKey;
                    category.CategoryID = LocationCategoryDAO.AddCategory(category);
                }
                //Thêm địa điểm
                Location location = new Location();
                location.Name = tenDiaDiem;
                location.Latitude = viDo;
                location.Longitude = kinhDo;
                location.Note = ghiChu;
                location.CategoryID = category.CategoryID;
                location.Deleted = false;
                //Gán lại ID và kiểm tra
                location.LocationID = LocationDAO.AddLocation(location);
                if (location.LocationID.ToString() == "")
                    return 0;
                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        [System.Web.Services.WebMethod]
        public static bool CapNhatDiaDiem(string maDiaDiem, string tenDiaDiem, float viDo, float kinhDo, string ghiChu)
        {
            try
            {
                //LocationCategory category = new LocationCategory();
                //category.Name = "";
                //category.UserID = (Guid)Membership.GetUser().ProviderUserKey;
                //category.CategoryID = LocationCategoryDAO.AddCategory(category);

                Location location = LocationDAO.FindLocation(maDiaDiem);
                location.Name = tenDiaDiem;
                location.Longitude = kinhDo;
                location.Latitude = viDo;
                location.Note = ghiChu;

                if (LocationDAO.UpdateLocation(location).ToString() == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [System.Web.Services.WebMethod]
        public static bool XoaDiaDiem(string maDiaDiem)
        {
            try
            {
                if (LocationDAO.RemoveLocation(maDiaDiem))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [System.Web.Services.WebMethod]
        public static string[] TimDiaDiemGanNhat(float viDoHienTai, float kinhDoHienTai, string danhMucTimKiem)
        {
            Location currentLocation = new Location();
            currentLocation.Latitude = viDoHienTai;
            currentLocation.Longitude = kinhDoHienTai;
            LocationCategory category = LocationCategoryDAO.FindCategory(danhMucTimKiem, Membership.GetUser());
            List<Location> dsDiaDiem = LocationDAO.FindLocation(category);

            double minDistance = LocationDAO.FindDistance(currentLocation, dsDiaDiem[0]);
            int index = 0;
            for (int i = 0; i < dsDiaDiem.Count; ++i)
            {
                if (LocationDAO.FindDistance(currentLocation, dsDiaDiem[i]) < minDistance)
                {
                    minDistance = LocationDAO.FindDistance(currentLocation, dsDiaDiem[i]);
                    index = i;
                }
            }
            string[] result = new string[2];
            result[0] = dsDiaDiem[index].Name;
            result[1] = dsDiaDiem[index].Note;
            return result;
            //return dsDiaDiem[index].Name;
            //return String.Empty;
        }       
    }
}