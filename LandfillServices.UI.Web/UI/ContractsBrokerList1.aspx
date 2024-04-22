<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractsBrokerList1.aspx.cs" Inherits="LandfillServices.UI.Web.UI.ContractsBrokerList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
    <div class="row">
        <div class="col-lg-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Contracts Broker List</h5> 
                 <%--   //Page title--%>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>
                    </div>
                </div>
               
                <div class="ibox-content">
                    <div class="table-responsive">
                        <asp:Repeater ID="RepeaterListContractsBroker" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped table-bordered table-hover dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>Company broker</th> 
                                              <th>Number</th> 
                                             <th>Subscription date</th> 
                                              <th>Termination date</th> 
                                             <th>Status</th> 
                                             
                                            <th></th>

                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="gradeX">
                                    <td>
                                        <asp:Label runat="server" ID="Label7" Text='<%# Eval("BrokerCompanyCoperateName") %>' /> 
                                           </td>
                                    <td>
                                        <asp:Label runat="server" ID="Label8" Text='<%# Eval("Number") %>' />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Label6" Text='<%# Eval("SubscriptionDateFormatted") %>' />
                                    </td>
                                     <td>
                                        <asp:Label runat="server" ID="Label1" Text='<%# Eval("TerminationDateFormatted") %>' />
                                    </td>
                                     <td>
                                        <asp:Label runat="server" ID="Label3" Text='<%# Eval("Status") %>' />
                                    </td>
                                    <td>
                                        <a href='/UI/ContractsBrokerEdit.aspx?ID=<%# Eval("ID") %>'>
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
