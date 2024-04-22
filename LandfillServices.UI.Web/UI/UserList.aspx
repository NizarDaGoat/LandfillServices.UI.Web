<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="LandfillServices.UI.Web.UI.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>User List</h5> 
                     <%--   //Page title--%>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:Repeater ID="RepeaterListUser" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover dataTables-example">
                                        <thead>
                                            <tr>
                                                <th>Company Coperate</th> 
                                                <%--//The Company--%>
                                                <th>Identity</th> 
                                              <%--  //Your ID--%>
                                                <th>Email</th> 
                                                <%--Your Email--%>
                                                <th></th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td>
                                            <asp:Label runat="server" ID="Label7" Text='<%# Eval("CompanyCoperateName") %>' /> 
                                            <%--Need to write it again but the same naming as the variablre declared in the SQL server database--%>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("FirstLastName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("Email") %>' />
                                        </td>
                                        <td>
                                            <a href='/UI/EditUser.aspx?ID=<%# Eval("ID") %>'>
                                                <asp:Label runat="server" ID="Label2" Text="Details" /></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>

                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
