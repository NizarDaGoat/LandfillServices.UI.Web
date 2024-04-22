<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogisticCommissionsForAccounting.aspx.cs" Inherits="LandfillServices.UI.Web.UI.LogisticCommissionsForAccounting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Logistic commissions to accounting</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="form-horizontal panel-body">
                        <asp:Panel runat="server" ID="PanelSaveAccounting" Visible="false">
                            <div class="col-lg-12">
                                <div class="alert alert-info">
                                    <a href="#" class="close" data-dismiss="alert">&times;</a>
                                    <strong></strong>The commission has been successfully made 
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PanelControlsChecked" Visible="false">
                            <div class="col-lg-12">
                                <div class="alert alert-warning">
                                    <a href="#" class="close" data-dismiss="alert">&times;</a>
                                    <strong></strong>Select a line
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="form-group">
                            <div class="col-lg-6">
                                <asp:Button ID="ButtonSelect" runat="server" Text="Select" CssClass="btn btn-primary left" OnClick="ButtonSelect_Click" />
                                <%--//This is a Button  for select/unselect--%>
                            </div>
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="table-responsive">
                            <div class="table table-striped table-bordered table-hover table-responsive SelecteurGridView">
                                <asp:GridView ID="GridViewCommissions" runat="server" OnRowCreated="GridViewCommissions_RowCreated"
                                    AutoGenerateColumns="False" Width="100%" DataKeyNames="ID"
                                    AllowSorting="True" OnSorting="GridViewCommissions_Sorting" OnRowDataBound="GridViewCommissions_RowDataBound">
                                    <PagerSettings Mode="Numeric" Position="Bottom" Visible="false" />
                                    <Columns>
                                        <asp:BoundField DataField="CompanyCoperateName" HeaderText="Logistic" SortExpression="CompanyCoperateName" />
                                        <asp:BoundField DataField="ContractNumber" HeaderText="Contract" SortExpression="ContractNumber" />
                                         <asp:BoundField DataField="CreatedFormatted" HeaderText="Date" SortExpression="CreatedFormatted" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount(£)" SortExpression="Amount" />
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <HeaderTemplate>
                                                &nbsp;<asp:CheckBox ID="chkAllSelect" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllSelect_CheckedChanged"
                                                    ToolTip="Check/Uncheck all" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
