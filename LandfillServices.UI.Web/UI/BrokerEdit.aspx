<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrokerEdit.aspx.cs" Inherits="LandfillServices.UI.Web.UI.BrokerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Broker Edit </h5>
                        <%--//Title page--%>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>

                    <div class="ibox-content">

                        <div class="form-horizontal panel-body">
                            <asp:Panel runat="server" ID="PanelSaveInformations" Visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-info">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <strong></strong>The informations has been recorded successfully 
                                        <%--//When infomation is saved it will indicate it has been saved or otherwise--%>
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
                                    <%--//This is a textbox to write in for your Company--%>
                                </div>
                                <label class="col-lg-4 control-label">Company Registration Number</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxCompanyRegistrationNumber" name="CompanyRegistrationNumber" runat="server" placeholder="Company Coperate..." CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your Company--%>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">First name</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxFirstName" name="FirstName" runat="server" placeholder="FirstName" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your FirstName--%>
                                </div>
                                <label class="col-lg-4 control-label">Last name</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxLastName" name="LastName" runat="server" placeholder="Surname" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your LastName--%>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-4 control-label">Address</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxAddress" name="Address" runat="server" placeholder="Address" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your Adress--%>
                                </div>
                                <label class="col-lg-4 control-label">City</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxCity" name="City" runat="server" placeholder="City" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your City--%>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-4 control-label">Email</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxEmail" name="Email" runat="server" placeholder="Email" CssClass="form-control" type="email"></asp:TextBox>
                                    <%--//This is a textbox to write in for your FirstName--%>
                                </div>
                                <label class="col-lg-4 control-label">PhoneNumber</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPhoneNumber" name="PhoneNumber" runat="server" placeholder="PhoneNumber" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="phone is required" ForeColor="Red"
                                        ControlToValidate="TextBoxPhoneNumber"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Phone is not valid"
                                        ValidationExpression="^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"
                                        ControlToValidate="TextBoxPhoneNumber"></asp:RegularExpressionValidator>
                                    <%--//This is a textbox to write in for your PhoneNumber--%>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="ButtonSave_Click" />
                                    <%--//This is a Button  for Saving your infomation--%>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>

