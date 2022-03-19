<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="ProjectX.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<head runat="server">
    <title>Sign up - Online Examination System</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content="The Developers"/>
    <meta name="generator" content="Hugo 0.88.1"/>

    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet"/>
    <link href="/Content/CSS/bootstrap.min.css" rel="stylesheet" />

    <style>
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

      .genbox{
          border: 1px solid #cfc9c9;
          border-radius: 4px;
          padding: 5px 5px 4px 10px;
      }

      .button{
          font-size: 17px;
          margin-top: 29px;
          background-color: #6977eb;
          border-color: #6977eb;
      }

      .button:hover{
          background-color: #3498db;
          border-color: #3498db;
      }

      .link{
          margin-top: -10px;
          margin-left: 183px;
          position: relative;
          top: -1px;
          text-decoration: none;
          font-family: "Open Sans", sans-serif;
          font-size: 15px;
          color: #0d6efd;
      }

      .link:hover{
          text-decoration: underline;
      }

      .logo{
          position: relative;
          top: -125px;
          left: 92px;
      }

      .image{
          position: relative;
          top: -35px;
          left: -20px;
      }

      .cover{
          border: 1px solid #cfc9c9;
          padding-bottom: 30px;
          padding-left: 30px;
          border-radius: 5px;
          box-shadow: 1px 2px 5px rgba(59, 57, 57, 0.1);
          position: relative;
      }

      .pos-a{
          position: absolute;
          top: 293px;
          left: 723px;
      }

      .heading{
          position: relative;
          top: -2px;
      }

      .ftr{
          margin-top: -38px;
          font-family: "Open Sans", sans-serif;
          font-size: 15px;
      }

      .f-link:hover{
          color: #1a2be8
      }

      #errorMsg{
          margin-left: 9px;
      }

      #errorMsg1{
          margin-left: -3px;
      }

      #RequiredFieldValidator3{
          margin-left: -10px;
      }

      .rbl input[type="radio"]
      {
         margin-left: 11px;
         margin-right: 4px;
      }

      .line{
          color: #454545;
          position: relative;
          top: -1px;
      }

      .home-link{
            display: inline;
            position: absolute;
            top: 541px;
            left: 925px;
      }

      h2{
          font-family: "Raleway", sans-serif;
      }

      .main-heading{
          font-weight: 600;
          font-size: 31px;
          position: relative;
          top: 2px;
      }

      /*#signupbtn:disabled{
          color: #fff;
          background-color: #0d6efd;
          border-color: #0d6efd;
      }*/
    </style>

    <link href="/Content/CSS/form-validation.css" rel="stylesheet" />
</head>

<body>

    <div class="container">
        
        <main>

            <div class="py-5 text-center heading">
                <h2 class="main-heading">Online Examination System</h2>
                <p class="lead">Life is hard enough already. Let us make it a little easier.</p>
            </div>

            <div class="row g-5 cover">

                <div class="col-md-5 col-lg-4 order-md-last">
                    <img class="d-block mx-auto mb-4 image" src="/Content/Images/img1.jpg" alt="Error loading image" width="280"/>
                    <h4 class="d-flex justify-content-between align-items-center mb-3">
                        <span class="text-primary logo">OES</span>
                    </h4>
                </div>

                <div class="col-md-7 col-lg-8">

                    <h4 class="mb-3">Create Your Account</h4>

                    <form class="needs-validation" runat="server">

                        <div class="row g-3">

                            <div class="col-sm-6">
                                <label runat="server" for="fname" class="form-label">First Name</label> 
                                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="fname" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                                <asp:TextBox runat="server" type="text" placeholder="First Name" ID="fname" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-6">
                                <label runat="server" for="lname" class="form-label">Last Name</label> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lname" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                                <asp:TextBox runat="server" type="text" placeholder="Last Name" ID="lname" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-12">
                                <label runat="server" for="email" class="form-label">Email Address</label>
                                <asp:Label ID="errorMsg" ForeColor="Red" Text="  " runat="server" Font-Size="13px"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                                <asp:TextBox runat="server" type="email" placeholder="Email Address" ID="email" CssClass="form-control" OnTextChanged="EmailCheck" AutoPostBack="true"></asp:TextBox>
                            </div>

                            <div class="col-sm-6">
                                <label runat="server" for="pass" class="form-label">Password</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pass" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                                <asp:TextBox runat="server" type="password" placeholder="Password" ID="pass" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-6">
                                <label runat="server" for="cpass" class="form-label">Confirm</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cpass" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                                <asp:CompareValidator ErrorMessage="* Password do not match" ControlToValidate="cpass" ControlToCompare="pass" runat="server" ForeColor="Red" Font-Size="13px" ID="errorMsg1"/>
                                <asp:TextBox runat="server" type="password" placeholder="Confirm Password" ID="cpass" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-6">
                                <label runat="server" for="gen" class="form-label">Gender</label> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="gen" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                                <div class="genbox">
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="gen" CssClass="rbl">
                                        <asp:ListItem Text=" Male" value="Male"/>
                                        <asp:ListItem Text=" Female" value="Female"/>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                           <div class="col-sm-6">
                               <label runat="server" for="dob" class="form-label">Date of Birth</label>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="dob" ErrorMessage=" *" ForeColor="Red" Font-Bold="true"/>
                               <asp:TextBox runat="server" type="date" ID="dob" CssClass="form-control"></asp:TextBox>
                           </div>

                           <asp:Button runat="server" Text="Sign up" ToolTip="Sign up" CssClass="w-100 btn btn-primary btn-lg button" OnClick="Signup" ID="signupbtn"></asp:Button>
                     
                           <hr class="my-4 line"/>

                           <asp:HyperLink NavigateUrl="Login.aspx" runat="server" Text="Already have an account? Sign in" CssClass="link-primary link"/>
                              
                       </div>

                        <div class="col-md-2 pos-a">
                            <label runat="server" for="option" class="form-label">Select Your Semester</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="option" ErrorMessage="  *" ForeColor="Red" Font-Bold="true"/>
                            <asp:DropDownList runat="server" CssClass="form-select" ID="option">
                               <asp:ListItem Text="Select..." value=""/>
                               <asp:ListItem Text="1st semester" value="1"/>
                               <asp:ListItem Text="2nd semester" value="2"/>
                               <asp:ListItem Text="3rd semester" value="3"/>
                               <asp:ListItem Text="4th semester" value="4"/>
                               <asp:ListItem Text="5th semester" value="5"/>
                           </asp:DropDownList> 
                        </div>

                    </form>

                    <div class="home-link">
                        <a href="/Home/Index.aspx" class="home"><img src="/Content/Images/back-arrow1.png" alt="" width="27"/></a>
                    </div>

                </div>

            </div>

        </main>

        <footer class="my-5 pt-5 text-muted text-center text-small">
            <div class="ftr">
                <p class="mb-1">&copy; 2021-2023 ProjectX</p>
            </div> 
        </footer>

    </div>

</body>

</html>