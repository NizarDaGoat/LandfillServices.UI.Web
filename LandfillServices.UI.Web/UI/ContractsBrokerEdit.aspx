<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractsBrokerEdit.aspx.cs" Inherits="LandfillServices.UI.Web.UI.ContractsBrokerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Contracts Broker Edit </h5>
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
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="PanelControlsValues" Visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-warning">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <strong></strong>The broker and subsciption date is required
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Broker *</label>
                                <div class="col-lg-2">
                                    <asp:DropDownList ID="DropDownListBroker" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group" id="data_1">
                                <label class="col-lg-4 control-label">Subscription date *</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxSubscriptionDate" name="SubscriptionDate" runat="server" placeholder="SubscriptionDate" CssClass="form-control"></asp:TextBox>
                                </div>

                                <label class="col-lg-4 control-label">Termination date</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxTerminationDate" name="TerminationDate" runat="server" placeholder="TerminationDate" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Policy number</label>
                                <div class="col-lg-2">
                                    <asp:Label ID="LabelNumber" name="Number" runat="server" placeholder="Number" CssClass="form-control"></asp:Label>
                                </div>
                                <label class="col-lg-4 control-label">Status *</label>
                                <div class="col-lg-2">
                                    <asp:DropDownList ID="DropDownListStatus" runat="server">
                                    </asp:DropDownList>
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
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Contrats Broker Remunerated Settings
                </div>
                <div class="form-horizontal panel-body">
                    <div class="form-group">
                          <div class="table table-striped table-bordered table-hover table-responsive SelecteurGridView">
                            <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                OnSelectedIndexChanging="GridViewList_SelectedIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                                      <asp:BoundField DataField="Value" HeaderText="Value(£)" SortExpression="Value" />
                                     <asp:BoundField DataField="StartDateFormatted" HeaderText="start Date" SortExpression="StartDateFormatted" />
                                    <asp:BoundField DataField="EndDateFormatted" HeaderText="End Date" SortExpression="EndDateFormatted" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/UI/Images/page_edit.png"
                                        ShowSelectButton="True" SelectText="Edit" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="30px" />

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:LinkButton ID="LinkButtonAdd" runat="server" CssClass="DetailLink" OnClick="LinkButtonAdd_Click">ADD...</asp:LinkButton>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <asp:Panel runat="server" ID="PanelAdd" Visible="false">
                        <asp:Panel runat="server" ID="PanelControlRemuneratedParameters" Visible="false">
                            <div class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert">&times;</a>
                                <strong></strong>Product, value, and start date is required
                            </div>
                        </asp:Panel>
                        <div class="form-group">

                            <label class="col-lg-4 control-label">Product</label>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="DropDownListProduct" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div>
                                <label for="TextBoxDecimalValue" class="col-lg-4 control-label">Value</label><label class="etoile">*</label>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox TabIndex="15" type="decimal" runat="server" class="saisieTextbox" ID="TextBoxDecimalValue"></asp:TextBox><label class="etoile">£</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-4 control-label">Start date</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="TextBoxStartDate" name="Start date" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-lg-4 control-label">End date</label>
                            <div class="col-lg-2">
                                <asp:TextBox ID="TextBoxEndDate" name="End date" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-offset-4 col-lg-8">
                                <asp:Button ID="ButtonSaveParameter" runat="server" OnClick="ButtonSaveParameter_Click" Text="Saved" CssClass="btn btn-primary pull-center" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>


