<%@ Page Title="" Language="C#" MasterPageFile="~/Register.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LandfillServices.UI.Web.UI.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Register Page </h5>
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
                                        <strong></strong>the password must contain at least one lowercase letter, one uppercase letter, one number and one special character
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="PanelEmailExisting" Visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <strong></strong>this email is already in use
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Company coperate</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxCompanyCoperate" name="Company Coperte" runat="server" placeholder="Company Coperate..." CssClass="form-control"></asp:TextBox>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">First name</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxFirstName" name="FirstName" runat="server" placeholder="FirstName" CssClass="form-control"></asp:TextBox>
                                </div>
                                <label class="col-lg-4 control-label">Last name</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxLastName" name="LastName" runat="server" placeholder="Surname" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-4 control-label">Address</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxAddress" name="Address" runat="server" placeholder="Address" CssClass="form-control"></asp:TextBox>
                                </div>
                                <label class="col-lg-4 control-label">City</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxCity" name="City" runat="server" placeholder="City" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-4 control-label">Email</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxEmail" name="Email" runat="server" placeholder="Email" CssClass="form-control" type="email" required="true"></asp:TextBox>
                                </div>
                                <label class="col-lg-4 control-label">PhoneNumber</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPhoneNumber" name="PhoneNumber" runat="server" placeholder="PhoneNumber" CssClass="form-control" type="phone"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="phone is required" ForeColor="Red"
                                        ControlToValidate="TextBoxPhoneNumber"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Phone is not valid"
                                        ValidationExpression="^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"
                                        ControlToValidate="TextBoxPhoneNumber"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Password</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPassword" name="Password" runat="server" placeholder="Password" CssClass="form-control" type="password" required="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="password is required" ForeColor="Red"
                                        ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ErrorMessage="the password must contain at least one lowercase letter, one uppercase letter, one number and one special character" ForeColor="Red"
                                        ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"
                                        ControlToValidate="TextBoxPassword"></asp:RegularExpressionValidator>
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


