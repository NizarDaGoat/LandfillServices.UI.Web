<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PassageLandfillListByUser.aspx.cs" Inherits="LandfillServices.UI.Web.UI.PassageLandfillListByUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Passage Of Landfill List</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:Repeater ID="RepeaterListPassageLandfill" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover">
                                        <thead>
                                            <tr>

                                               
                                                <th>DateofPassage</th>
                                                <th>Pay ?</th>


                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">

                                        
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("DateOfPassageFormatted") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("PayDisplay") %>' />
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
