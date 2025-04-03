<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="navbar.aspx.cs" Inherits="Ecomm.navbar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark px-4">
            <a class="navbar-brand" href="#">Ecomm</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item"><a class="nav-link active" href="Login.aspx">התחברות</a></li>
                    <li class="nav-item"><a class="nav-link" href="#">הרשמה</a></li>
                    <li class="nav-item"><a class="nav-link" href="#">צור קשר</a></li>
                </ul>
            </div>
        </nav>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
