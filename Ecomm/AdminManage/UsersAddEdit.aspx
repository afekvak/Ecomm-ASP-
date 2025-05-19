<%@ Page Title="" Language="C#" MasterPageFile="~/AdminManage/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UsersAddEdit.aspx.cs" Inherits="Ecomm.AdminManage.UsersAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCnt" runat="server">
    <h2 class="page-title">עריכת משתמשים</h2>
    <p class="text-muted">נא להזין את פרטי המשתמש</p>
    <div class="card-deck">
        <div class="card shadow mb-4">
            <div class="card-header">
                <strong class="card-title">פרטי המשתמש</strong>
            </div>
            <div class="card-body">

                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="TxtFullName">שם משתמש</label>
                        <asp:TextBox ID="TxtFullName" runat="server" class="form-control" placeholder="יש להזין שם משתמש" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="TxtEmail">מייל</label>
                        <asp:TextBox ID="TxtEmail" runat="server" class="form-control" placeholder="יש להזין שם משתמש" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <label for="TxtPhone">טלפון</label>
                        <asp:HiddenField ID="HidUid" runat="server" Value="-1" />
                        <asp:TextBox ID="TxtPhone" runat="server" class="form-control" placeholder="יש להזין שם טלפון" />
                    </div>
                    
                   
                    <div class="form-group col-md-6">
                        <label for="TxtAdress">כתובת</label>
                        <asp:TextBox ID="TxtAdress" runat="server" class="form-control" TextMode="MultiLine" Columns="40" Rows="10" placeholder="יש להזין כתובת" />
                    </div>
                </div>

                <asp:Button ID="BtnSave" Text="שמור" runat="server" class="btn btn-primary" onClick="BtnSave_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CntFooter" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CntUnderFooter" runat="server">
</asp:Content>