<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrokerPassageProductList.aspx.cs" Inherits="LandfillServices.UI.Web.UI.BrokerPassageProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Broker Passage List</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:Repeater ID="RepeaterListPassage" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover dataTables-example">
                                        <thead>
                                            <tr>
                                                 <th>Broker</th>
                                                <th>Contract</th>
                                                <th>Product</th>
                                                <th>Date</th>
                                                 <th>Weight (Kg)</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                         <td>
                                            <asp:Label runat="server" ID="Label3" Text='<%# Eval("BrokerCompanyCoperateName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("ContractNumber") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("ProductName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("DateFormatted") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("Weight") %>' />
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

