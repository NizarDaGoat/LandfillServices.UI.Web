<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LandfillServices.UI.Web.UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    

        <asp:TextBox ID="TextBoxLogin" name="username" runat="server" placeholder="Login" CssClass="form-control" type="email" required="true"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxPassword" name="password" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control"></asp:TextBox><br />

        <div id="divErrorConnection" visible="false" runat="server">
            <p style="font-size: 16px; padding-top: 30px;">Error login or passeword</p>
        </div>

        <asp:Button ID="Button1" runat="server" Text="Connection" OnClick="Button1_Click" class="button connect" />

        <asp:CustomValidator ID="CostumValidatorLoginPassword" runat="server" ErrorMessage="" OnServerValidate="validateLoginPassword"></asp:CustomValidator>


        <div>
            <asp:LinkButton ID="LinkButtonLostPassword" OnClick="LinkButtonLostPassword_Click" class="lost" runat="server">Forgotten your password ?</asp:LinkButton>
        </div> 
     <div>
     <asp:LinkButton ID="LinkButtonRegister" OnClick="LinkButtonRegister_Click" class="lost" runat="server">Dont have an account ? Register here</asp:LinkButton>
 </div>

</asp:Content> 
