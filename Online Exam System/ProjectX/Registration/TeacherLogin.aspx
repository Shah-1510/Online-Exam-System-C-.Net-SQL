<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherLogin.aspx.cs" Inherits="ProjectX.Registration.TeacherLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Log in - Online Examination System</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="The Developers" />
    <meta name="generator" content="Hugo 0.88.1" />

    <link href="/Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="/Content/CSS/login.css" rel="stylesheet" />

    <style>
        body{
            font-family: "Open Sans", sans-serif;
            font-size: 15px;
        }

        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }

        .cover {
            width: 140%;
            border: 1px solid #cfc9c9;
            border-radius: 5px;
            box-shadow: 1px 2px 5px rgba(59, 57, 57, 0.1);
            padding-top: 8px;
            padding-right: 30px;
            padding-left: 30px;
            padding-bottom: 18px;
            position: relative;
            top: 25px;
            left: -65px;
        }

        .container {
            margin-top: -17px;
        }

        #loginbtn {
            position: relative;
            top: 2px;
        }

        .hdg {
            position: relative;
            top: -1px;
            font-family: "Raleway", sans-serif;
        }

        .cp {
            position: relative;
            top: 30px;
        }

        .link {
            text-decoration: none;
            position: relative;
            top: -12px;
            left: 16px;
        }

        .link:hover {
            text-decoration: underline;
        }

        .button{
            font-size: 17px;
            background-color: #eb0303;
            border-color: #eb0303;
        }

        .button:hover{
            background-color: #f52828;
            border-color: #f52828;
        }

        .line{
            position: relative;
            top: -2px;
            color: #5c5c5c;
        }

        .email, .password{
            position: relative;
        }

        #rfv1, #rfv2{
            position: absolute;
            top: 6px;
            right: 10px;
        }

        .cbx{
            position: relative;
            top: 3px;
        }

        .error{
            margin-top: -2px;
            margin-bottom: 5px;
        }

        .home-link{
            display: inline;
            position: relative;
            top: 7px;
            left: 73px;
        }
    </style>
</head>

<body class="text-center">

    <main class="form-signin">

        <form runat="server">

            <div class="cover">

                <img class="mb-4" src="/Content/Images/img2.jpg" alt="Error loading image" width="183" />

                <div class="container">

                    <h3 class="mb-3 fw-normal hdg">Sign in</h3>

                    <div class="form-floating email"> 
                        <asp:TextBox type="email" class="form-control" ID="floatingInput" placeholder="name@example.com" runat="server"/>
                        <label for="floatingInput">Email address</label>
                        <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="floatingInput" Display="Dynamic" ID="rfv1" ForeColor="red" Font-Bold="true" Font-Size="Larger" runat="server" />
                    </div>
                   
                    <div class="form-floating password">
                        <asp:TextBox type="password" class="form-control" ID="floatingPassword" placeholder="Password" runat="server" />
                        <label for="floatingPassword">Password</label>
                        <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="floatingPassword" Display="Dynamic" ID="rfv2" ForeColor="red" Font-Bold="true" Font-Size="Larger" runat="server" />
                    </div>

                    <div class="error">
                        <asp:Label ID="errorMsg" ForeColor="Red" Text="" runat="server" Font-Size="13px"/>
                    </div>

                    <div class="checkbox mb-3 cbx">
                        <label>
                            <asp:CheckBox Text="&nbsp;Remember me" Value="remember-me" runat="server" ID="check"/>
                        </label>
                    </div>

                    <asp:Button runat="server" Text="Log in" CssClass="w-100 btn btn-lg btn-primary button" type="submit" OnClick="Signin" ID="loginbtn" OnClientClick="Signin"></asp:Button>

                    <hr class="my-4 line" />

                    <asp:HyperLink NavigateUrl="Signup.aspx" runat="server" Text="Don't have an account? Register" CssClass="link-primary link" />
 
                    <div class="home-link">
                        <a href="/Home/Index.aspx" class="home"><img src="/Content/Images/back-arrow.png" alt="" width="22"/></a>
                    </div>
                    
                </div>

            </div>

            <p class="mt-5 mb-3 text-muted cp">&copy; 2021-2023 ProjectX</p>

        </form>

    </main>

</body>

</html>
