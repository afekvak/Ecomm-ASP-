<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ecomm.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>התחברות</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: linear-gradient(to right, #74ebd5, #acb6e5);
            height: 100vh;
            display: flex;
            flex-direction: column;
        }
        .login-container {
            margin-top: 50px;
            background-color: #ffffffcc;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0,0,0,0.2);
        }
        
    </style>
</head>
<body>
    
    <form id="form1" runat="server" class="flex-grow-1 d-flex align-items-center justify-content-center">
        <div class="login-container col-lg-4 col-md-6 col-sm-10">
            <h3 class="text-center mb-4">התחברות למערכת</h3>
            <div class="mb-3">
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="אימייל" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="TxtPass" runat="server" CssClass="form-control" TextMode="Password" placeholder="סיסמה" />
            </div>
            <div class="d-grid mb-3">
                <asp:Button ID="BtnLogin" runat="server" CssClass="btn btn-success" Text="התחבר" OnClick="BtnLogin_Click" />
            </div>
            <div class="text-center text-danger">
                <asp:Literal ID="Ltlmsg" runat="server" />
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
