<%@ Page Title="" Language="C#" MasterPageFile="~/Register.Master" AutoEventWireup="true" CodeBehind="ForgottenPassword.aspx.cs" Inherits="LandfillServices.UI.Web.UI.ForgottenPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Create new password </h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="form-horizontal panel-body">

                            <asp:Panel runat="server" ID="PanelCheckPassword" Visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <strong></strong>the passwords should be identical
 
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="PanelControlEmailUserExiste" Visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <strong></strong>Email does not exist
 
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Email</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxEmail" name="Email" runat="server" placeholder="Email" CssClass="form-control" type="email" required="true"></asp:TextBox>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">New Password</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPassword" name="Password" runat="server" placeholder="Password" CssClass="form-control" type="password" required="true"></asp:TextBox>

                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="password is required" ForeColor="Red"
                                    ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ErrorMessage="the password must contain at least one lowercase letter, one uppercase letter, one number and one special character"
                                    ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"
                                    ControlToValidate="TextBoxPassword"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Confirmed Password</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPassword2" name="Password" runat="server" placeholder="Password" CssClass="form-control" type="password" required="true"></asp:TextBox>

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="ButtonSave_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
