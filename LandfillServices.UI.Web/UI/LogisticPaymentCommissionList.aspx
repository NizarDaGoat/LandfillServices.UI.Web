<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogisticPaymentCommissionList.aspx.cs" Inherits="LandfillServices.UI.Web.UI.LogisticPaymentCommissionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Logistic commissions List</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <asp:Repeater ID="RepeaterListCommissions" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-bordered table-hover dataTables-example">
                                        <thead>
                                            <tr>
                                                <th>Logistic</th>
                                                <th>Contract</th>
                                                <th>Product</th>
                                                <th>Date</th>
                                                <th>Amount(£)</th>
                                                <th>Date of payment</th>

                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="gradeX">
                                        <td>
                                            <asp:Label runat="server" ID="Label3" Text='<%# Eval("CompanyCoperateName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label8" Text='<%# Eval("ContractNumber") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label1" Text='<%# Eval("ProductName") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label6" Text='<%# Eval("CreatedFormatted") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label4" Text='<%# Eval("Amount") %>' />
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="Label2" Text='<%# Eval("PaymentDateFormatted") %>' />
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
