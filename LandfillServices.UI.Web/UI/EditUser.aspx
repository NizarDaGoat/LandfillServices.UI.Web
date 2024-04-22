<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="LandfillServices.UI.Web.UI.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>User Edit </h5>
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
                                    <div class="alert alert-warning">
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
                                    <asp:TextBox ID="TextBoxEmail" name="Email" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your FirstName--%>
                                </div>
                                <label class="col-lg-4 control-label">PhoneNumber</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPhoneNumber" name="PhoneNumber" runat="server" placeholder="PhoneNumber" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your PhoneNumber--%>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Password</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxPassword" name="Password" runat="server" placeholder="Password" CssClass="form-control"></asp:TextBox>
                                    <%--//This is a textbox to write in for your Password--%>
                                </div>
                                <label class="col-lg-4 control-label">User Type</label>
                                <div class="col-lg-2">
                                    <asp:RadioButtonList ID="RadioButtonListUserType" runat="server">
                                        <asp:ListItem Value="1">Adminstrator</asp:ListItem>
                                        <asp:ListItem Value="2">Operator</asp:ListItem>
                                        <asp:ListItem Value="3">Public</asp:ListItem>
                                        <%--//This is a RadioButtonList to write in for your Authority in the Landfill system there are 3 levels 3 being the lowest and 1 being the Highest--%>
                                    </asp:RadioButtonList>
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

                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:Repeater ID="RepeaterListPassageLandfill" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>Date of passage</th>
                                                <th>pay</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td>
                                            <asp:Label runat="server" ID="Label7" Text='<%# Eval("DateOfPassageFormatted") %>' />
                                            <%--//When did the Passage happen--%>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("PayDisplay") %>' />
                                            <%-- //Dispalys whether or not the passage was paid for or not--%>
                                        </td>

                                    </tr>
                                </ItemTemplate>

                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>

                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="ibox-content">

                        <div class="form-horizontal panel-body">
                            <%--    //Write in the date for the date of passage--%>
                            <div class="form-group" id="data_1">
                                <label class="col-lg-4 control-label">Date Of Passage</label>
                                <div class="col-lg-2">
                                    <div class="input-group date">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>

                                        <asp:TextBox ID="TextBoxDateOfPassage" name="Date Of Passage" runat="server" placeholder="Date Of Passage" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Pay ? </label>
                                <div class="col-lg-2">
                                    <asp:RadioButtonList ID="RadioButtonListPay" runat="server">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>

                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button ID="ButtonSavePassage" runat="server" Text="Save Passage" CssClass="btn btn-primary" OnClick="ButtonSavePassage_Click" />
                                    <%--//Button to save the passage--%>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
