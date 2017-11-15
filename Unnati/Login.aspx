<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Unnati.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <title>Sign In | Unnati</title>

    <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css" />
    <link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="plugins/node-waves/waves.css" rel="stylesheet" />
    <link href="plugins/animate-css/animate.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />


    <script src="plugins/jquery/jquery.min.js"></script>
    <script src="plugins/bootstrap/js/bootstrap.js"></script>
    <script src="plugins/node-waves/waves.js"></script>
    <script src="plugins/jquery-validation/jquery.validate.js"></script>
    <script src="js/admin.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById("loginDiv").style.display = "block";
            document.getElementById("signUpDiv").style.display = "none";
            document.getElementById("forgotPassDiv").style.display = "none";
        })

        function ShowRegister() {
            document.getElementById("loginDiv").style.display = "none";
            document.getElementById("signUpDiv").style.display = "block";
            document.getElementById("forgotPassDiv").style.display = "none";
        }
        function ShowSignIn() {
            document.getElementById("loginDiv").style.display = "block";
            document.getElementById("signUpDiv").style.display = "none";
            document.getElementById("forgotPassDiv").style.display = "none";
        }
        function showForgotPass() {
            document.getElementById("loginDiv").style.display = "none";
            document.getElementById("signUpDiv").style.display = "none";
            document.getElementById("forgotPassDiv").style.display = "block";
        }
    </script>
    <style>
        .backgroundImage {
            background-color: #cbe4f1;
            /*background-image: url('images/background1.jpg');*/
            z-index: -1;
        }
    </style>
</head>
<body class="login-page backgroundImage">



    <form id="form1" runat="server" novalidate>
        <div class="login-box">
            <div class="logo">
                <a href="javascript:void(0);">
                    <img src="images/UnnatiLogo.png" style="height: 100px" /></a>
                <%--<small style="padding: 10px;color:black">UNNATI ENGINEERING WORKS</small>--%>
            </div>
            <div class="card" id="loginDiv">
                <div class="body">

                    <div class="msg">Sign in to start your session</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtUserName" class="form-control" placeholder="Username" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtPassword" type="password" class="form-control" placeholder="Password" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 p-t-5">
                        </div>
                        <div class="col-xs-4">
                            <asp:Button runat="server" ID="btnSignIn" class="btn btn-block bg-pink waves-effect" type="submit" Text="SIGN IN" OnClick="btnSignIn_Click" autopostback="true"></asp:Button>
                        </div>
                    </div>
                    <div class="row m-t-15 m-b--20">
                        <div class="col-xs-6">
                            <a href="#" onclick="ShowRegister()">Register Now!</a>
                        </div>
                        <div class="col-xs-6 align-right">
                            <a href="#" onclick="showForgotPass()">Forgot Password?</a>
                        </div>
                    </div>

                </div>
            </div>

            <div class="card" id="signUpDiv">
                <div class="body">

                    <div class="msg">Register a new membership</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtName" type="text" class="form-control" placeholder="Name Surname" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">email</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtUserEmail" type="email" class="form-control" placeholder="Email Address" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtUserPassword" type="password" class="form-control" minlength="6" placeholder="Password" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtUserConfirmPassword" type="password" class="form-control" minlength="6" placeholder="Confirm Password" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Button runat="server" ID="btnRegister" class="btn btn-block btn-lg bg-pink waves-effect" type="submit" Text="SIGN UP"></asp:Button>

                    <div class="m-t-25 m-b--5 align-center">
                        <a href="#" onclick="ShowSignIn()">You already have a membership?</a>
                    </div>

                </div>
            </div>

            <div class="card" id="forgotPassDiv">
                <div class="body">

                    <div class="msg">
                        Enter your email address that you used to register. We'll send you an email with your username and 
                       your password.
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">email</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox runat="server" ID="txtFEmail" type="email" class="form-control" placeholder="Email" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Button runat="server" ID="btnForgotPass" class="btn btn-block btn-lg bg-pink waves-effect" type="submit" Text="RESET MY PASSWORD"></asp:Button>

                    <div class="row m-t-20 m-b--5 align-center">
                        <a href="#" onclick="ShowSignIn()">Sign In!</a>
                    </div>

                </div>
            </div>
        </div>
    </form>

</body>
</html>
