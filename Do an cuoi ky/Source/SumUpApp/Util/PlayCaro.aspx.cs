﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Web.Security;
using System.Windows.Forms;
using Ajax;

namespace SumUpApp
{
    public partial class PlayCaro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentRoom"] == null)
                Session["CurrentRoom"] = -1;

            if (!ClientScript.IsStartupScriptRegistered("loadForm"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                    "load", "loadForm();", true);
            }

            Ajax.Utility.GenerateMethodScripts(this);

            UpdateForm();
        }

        private void UpdateForm()
        {
            UpdateRoomView();
            UpdateListRooms();
        }

        private void UpdateListRooms()
        {
            Room[] rooms = Global.roomManager.GetRoomList().ToArray();
            ddlRooms.DataTextField = "Name";
            ddlRooms.DataValueField = "Id";
            ddlRooms.DataSource = rooms;
            ddlRooms.DataBind();
        }

        private void UpdateRoomView()
        {
            if (int.Parse(Session["CurrentRoom"].ToString()) == -1)
            {
                RoomMultiView.SetActiveView(NoRoomView);
            }
            else
            {
                RoomMultiView.SetActiveView(InRoomView);
            }
        }

        protected void btnJoinRoom_Click(object sender, EventArgs e)
        {
            if (ddlRooms.SelectedIndex != -1)
            {
                int roomId = int.Parse(ddlRooms.SelectedItem.Value);
                Global.roomManager.JoinRoom(roomId, (Guid)Membership.GetUser().ProviderUserKey, Membership.GetUser().UserName);
                Session["CurrentRoom"] = roomId;

                UpdateForm();
            }
            else
                MessageBox.Show("It seem to be server does not have any room");
        }

        protected void btnCreateRoomMachine_Click(object sender, EventArgs e)
        {
            int roomId;
            Global.roomManager.CreateRoom((Guid)Membership.GetUser().ProviderUserKey, Membership.GetUser().UserName, true, out roomId);
            Session["CurrentRoom"] = roomId;

            UpdateForm();
        }

        protected void btnCreateRoomPlayer_Click(object sender, EventArgs e)
        {
            int roomId;
            Global.roomManager.CreateRoom((Guid)Membership.GetUser().ProviderUserKey, Membership.GetUser().UserName, false, out roomId);
            Session["CurrentRoom"] = roomId;

            UpdateForm();
        }

        protected void btnLeaveTheRoom_Click(object sender, EventArgs e)
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            Global.roomManager.LeaveRoom(roomId, (Guid)Membership.GetUser().ProviderUserKey);
            Session["CurrentRoom"] = -1;

            UpdateForm();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateForm();
        }

        #region Ajax

        [Ajax.AjaxMethod(false)]
        public bool IsMyTurn()
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            return Global.roomManager.IsMyTurn(roomId, (Guid)Membership.GetUser().ProviderUserKey);
        }

        [Ajax.AjaxMethod(false)]
        public int[] GetOpponentMove()
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            return Global.roomManager.GetLastMove(roomId);
        }

        [Ajax.AjaxMethod(false)]
        public bool IsGameOver()
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            return Global.roomManager.IsGameOver(roomId);
        }

        [Ajax.AjaxMethod(false)]
        public void UserMove(int x, int y)
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            Global.roomManager.Move(roomId, (Guid)Membership.GetUser().ProviderUserKey, x, y);
        }

        [Ajax.AjaxMethod(false)]
        public bool IsWin()
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            return Global.roomManager.IsWin(roomId, (Guid)Membership.GetUser().ProviderUserKey);
        }

        [Ajax.AjaxMethod(false)]
        public bool IsPlayWithMachine()
        {
            int roomId = int.Parse(Session["CurrentRoom"].ToString());
            return Global.roomManager.IsPlayWithMachine(roomId);
        }

        #endregion
    }
}