<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AdminManage._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>דף הבית - Ecomm</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', sans-serif;
            background: linear-gradient(to right, #e0eafc, #cfdef3);
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }
        iframe {
            border: none;
        }
        .hero {
            flex-grow: 1;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            text-align: center;
            padding: 50px 15px;
        }
        .hero h1 {
            font-size: 3rem;
            margin-bottom: 20px;
        }
        .hero p {
            font-size: 1.25rem;
            margin-bottom: 30px;
            color: #333;
        }
    </style>
</head>
<body>
    <!-- Navigation bar -->
    <iframe src="navbar.aspx" width="100%" height="80"></iframe>

    <form id="form1" runat="server" class="flex-grow-1">
        <div class="hero">
            <h1>ברוך הבא ל־Ecomm</h1>
            <p>המערכת המושלמת לניהול ההזמנות, הלקוחות והמוצרים שלך</p>
            <a href="Login.aspx" class="btn btn-primary btn-lg">התחבר עכשיו</a>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
