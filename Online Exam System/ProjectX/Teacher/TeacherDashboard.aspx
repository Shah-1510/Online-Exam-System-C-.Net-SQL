<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherDashboard.aspx.cs" Inherits="ProjectX.Teacher.TeacherDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Dashboard - Online Examination System</title>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <link rel="stylesheet" href="/Content/CSS/feather.css"/>
    <link rel="stylesheet" href="/Content/CSS/themify-icons.css"/>
    <link rel="stylesheet" href="/Content/CSS/vendor.bundle.base.css"/>

    <link rel="stylesheet" href="/Content/CSS/dataTables.bootstrap4.css"/>
    <link rel="stylesheet" type="text/css" href="/Content/CSS/select.dataTables.min.css"/>

    <link href="/Content/CSS/bootstrap.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/bootstrap-icons.css" rel="stylesheet"/>
    <link href="/Content/CSS/boxicons.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/glightbox.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/remixicon.css" rel="stylesheet"/>
    <link href="/Content/CSS/swiper-bundle.min.css" rel="stylesheet"/>

    <link href="https://unpkg.com/boxicons@2.0.9/css/boxicons.min.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.1/font/bootstrap-icons.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/remixicon@2.5.0/fonts/remixicon.css" rel="stylesheet"/>

    <link rel="stylesheet" href="/Content/CSS/teacherDashboard.css"/>

    <style>
        body {
            overflow-y: hidden;
        }

        :root {
            scroll-behavior: smooth;
        }

        #header .logo h1 {
            font-size: 28px;
            margin: 0;
            padding: 0;
            line-height: 1;
            font-weight: 700;
            letter-spacing: 1px;
            margin-left: 34px;
            position: relative;
            z-index: 100;
        }

        .navbar-menu-wrapper{
            position: relative;
            z-index: 50;
        }

        #header .logo h1 a, #header .logo h1 a:hover {
            color: #222222;
            text-decoration: none;
        }

        .collapse li{
            margin-left: -5px;
        }

        .preview-thumbnail{
            margin-left: -5px;
        }

        .preview-item-content{
            margin-right: 5px;
        }

        .notificationType{
            position: relative;
            top: 4px;
        }

        .notificationMsg{
            position: relative;
            top: -1px;
        }

        .notificationDate{
            position: relative;
            top: 1px;
        }

        .profileName{
            color: #131212;
            position: relative;
            right: -17px;
            margin-left: -49px;
            font-size: 15px;
        }

        #logout{
            border: none;
        }

        .enterLinkIcon{
            margin-top: -2px;
        }

        .enterLink{
            margin-top: 5px;
        }

        .enterLinkBox{
            cursor: pointer;
            padding: 0.687rem 1.562rem;
            margin-left: -8px;
            height: 40px;
            position: relative;
            top: -4px;
        }

        .enterLinkBox:hover, .enterLinkBox:focus{
            color: #16181b;
            text-decoration: none;
            background-color: #eaeaf1;
        }

        .ftr{
            margin-top: -7px;
        }

        .footer{
            border-top: 1px solid #cdcdcd;
        }

        .course{
            margin-left: 10px;
        }

        .courseLink{
            text-decoration: none;
        }

        .courseLink:hover{
            text-decoration: none;
        }

        #noCourse{
            color: black;
            position: relative;
            top: 2px;
            left: 160px;
            font-size: 15px;
        }

        .noCourseCard{
            width: 1800px;
            position: relative;
            top: 4px;
            left: -20px;
            height: 250px;
        }

        .crossIcon{
            position: absolute;
            top: 26px;
            left: 165px;
            font-size: 16px;
        }

        .card1 {
            margin-bottom: 30px;
            border: none;
            border-radius: 5px;
            box-shadow: 0px 0 30px rgba(1, 41, 112, 0.1);
            overflow: hidden;
            border-color: #ebeef4;
            background-color: #fff;
            position: relative;
            left: 7px;
            top: -4px;
        }

        .card-header, .card-footer {
            border-color: #ebeef4;
            background-color: #fff;
            color: #798eb3;
            padding: 15px;
        }

        .card-title1 {
            padding: 25px 0 14px 0;
            font-size: 18px;
            font-weight: 500;
            color: #012970;
            font-family: "Poppins", sans-serif;
            position: relative;
            top: 5px;
            left: 5px;
        }

        .card-title1 span {
            color: #899bbd;
            font-size: 16px;
            font-weight: 400;
        }

        .card-body1 {
            padding: 0 20px 7px 20px;
            position: relative;
            left: 5px;
        }

        .card-img-overlay {
            background-color: rgba(255, 255, 255, 0.6);
        }

        .cid{
            font-size: 18px;
            position: relative;
            top: -20px;
        }

        .cid span{
            font-size: 15px;
        }
    </style>
</head>

<body>
    <div class="container-scroller">
        <nav class="navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
            <div id="header" class="text-center navbar-brand-wrapper d-flex align-items-center justify-content-center">
                <div class="logo">
                    <h1><a href="/Teacher/TeacherDashboard.aspx">OES</a></h1>
                </div>
            </div>

            <div class="navbar-menu-wrapper d-flex align-items-center justify-content-end">
                <button class="navbar-toggler navbar-toggler align-self-center" type="button" data-toggle="minimize">
                    <i class="bi bi-list toggle-sidebar-btn"></i>
                </button>

                <ul class="navbar-nav mr-lg-2">
                    <li class="nav-item nav-search d-none d-lg-block">
                        <div class="input-group">
                            <div class="input-group-prepend hover-cursor" id="navbar-search-icon">
                                <span class="input-group-text" id="search">
                                    <i class="bi bi-search"></i>
                                </span>
                            </div>
                            <input type="text" class="form-control" id="navbar-search-input" placeholder="Search now" aria-label="search" aria-describedby="search" />
                        </div>
                    </li>
                </ul>

                <ul class="navbar-nav navbar-nav-right">
                    <li class="nav-item dropdown">

                        <a class="nav-link count-indicator dropdown-toggle" id="notificationDropdown" href="#" data-toggle="dropdown" runat="server">
                            <i class="bi bi-bell mx-0"></i>
                            <span class="count" id="notificationIcon" runat="server"></span>
                        </a>

                        <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="notificationDropdown">
                            <p class="mb-0 font-weight-normal float-left dropdown-header" id="notificationHeading" runat="server">Notifications</p>

                            <asp:Repeater ID="r1" runat="server">
                                <ItemTemplate>
                                    <a class="dropdown-item preview-item" href="/Teacher/TeacherNotification.aspx" runat="server">
                                        <div class="preview-thumbnail">
                                            <div class="preview-icon bg-danger">
                                                <i class="bi bi-info-circle mx-0"></i>
                                            </div>
                                        </div>

                                        <div class="preview-item-content">
                                            <h6 class="preview-subject font-weight-normal notificationType">
                                                <%#Eval("Type") %>
                                            </h6>
                                            <p class="font-weight-light small-text mb-0 text-muted notificationMsg">
                                                <%#getTwentyCharacters(Eval("Message")) %>
                                            </p>
                                            <p class="font-weight-light small-text mb-0 text-muted notificationDate">
                                                <%#Eval("Date") %>
                                            </p>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </li>

                    <li class="nav-item nav-profile dropdown">
                        <a class="nav-link dropdown-toggle profile" href="#" data-toggle="dropdown" id="profileDropdown">
                            <img src="/Content/Images/profile.jpg" alt="profile" />
                        </a>

                        <div class="dropdown-menu dropdown-menu-right navbar-dropdown" aria-labelledby="profileDropdown">             
                            <a class="dropdown-item" href="/Registration/TeacherLogin.aspx" onclick="<%Session.RemoveAll() %>" runat="server">
                                <i class="ri-shut-down-line text-primary"></i>
                                Logout
                            </a>
                        </div>
                    </li>

                    <li class="nav-item dropdown pe-3">
                        <a class="nav-link nav-profile d-flex align-items-center pe-0" href="/Student/Profile.aspx">
                            <span class="d-none d-md-block ps-2 profileName">
                                <asp:Label Text="" ID="nameLabel" runat="server" />
                            </span>
                        </a>
                    </li>
                </ul>

                <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="offcanvas">
                    <span class="icon-menu"></span>
                </button>
            </div>
        </nav>

        <div class="container-fluid page-body-wrapper">

            <nav class="sidebar sidebar-offcanvas" id="sidebar">
                <ul class="nav">

                    <li class="nav-item">
                        <a class="nav-link" href="/Teacher/TeacherDashboard.aspx">
                            <i class="bi bi-grid menu-icon"></i>
                            <span class="menu-title">Dashboard</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="/Teacher/TeacherQuiz.aspx">
                            <i class="bi bi-card-list menu-icon"></i>
                            <span class="menu-title">Quiz</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="/Teacher/TeacherResult.aspx">
                            <i class="bi bi-clipboard-check menu-icon"></i>
                            <span class="menu-title">Result</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="/Teacher/AddNotification.aspx">
                            <i class="bi bi-cloud-plus menu-icon"></i>
                            <span class="menu-title">Add Notification</span>
                        </a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" href="/Teacher/TeacherNotification.aspx">
                            <i class="bi bi-bell menu-icon"></i>
                            <span class="menu-title">Notifications</span>
                        </a>
                    </li>
                </ul>
            </nav>

            <div class="main-panel">

                <div class="content-wrapper">
                    <div class="row">
                        <div class="col-md-12 grid-margin">
                            <div class="row">
                                <div class="col-12 col-xl-8 mb-4 mb-xl-0">
                                    <h3 class="font-weight-bold">Teacher Panel</h3>
                                    <h6 class="font-weight-normal mb-0">All systems are running smoothly! <span id="topLabel" runat="server">You have <span class="text-primary">
                                        <asp:Label ID="notification" Text="" runat="server" />
                                        unread <span id="notifylabel" runat="server">alert!</span></span></span></h6>
                                </div>
                            </div>
                        </div>
                    </div>

                    <section class="section dashboard">
                        <div class="row">
                            <div class="stretch-card">
                                <div class="col-xl-4">
                                    <div class="card1 info-card sales-card">
                                        <div class="card-body1">
                                            <h5 class="card-title1">Course <span>| <asp:Label Text="" ID="courseLabel" runat="server" /></span></h5>
                                            <h5 class="card-title1 cid">Course ID <span>| <asp:Label Text="" ID="courseID" runat="server" /></span></h5> 
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>

                </div>

                <footer class="footer">
                    <div class="d-sm-flex justify-content-center justify-content-sm-between ftr">
                        <span class="text-muted text-center text-sm-left d-block d-sm-inline-block">Copyright © 2021. <a href="#" target="_blank">ProjectX</a>  by TheDevelopers. All rights reserved.</span>
                    </div>
                </footer>

            </div>
        </div>
    </div>

    <script src="/Content/JS/vendor.bundle.base.js"></script>
    <script src="/Content/JS/Chart.min.js"></script>
    <script src="/Content/JS/jquery.dataTables.js"></script>
    <script src="/Content/JS/dataTables.bootstrap4.js"></script>
    <script src="/Content/JS/dataTables.select.min.js"></script>
    <script src="/Content/JS/off-canvas.js"></script>
    <script src="/Content/JS/hoverable-collapse.js"></script>
    <script src="/Content/JS/template.js"></script>
    <script src="/Content/JS/settings.js"></script>
    <script src="/Content/JS/todolist.js"></script>

    <script src="/Content/JS/studentDashboard.js"></script>
</body>

</html>
