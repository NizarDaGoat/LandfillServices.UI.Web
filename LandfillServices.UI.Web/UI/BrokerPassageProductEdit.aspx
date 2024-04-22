<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrokerPassageProductEdit.aspx.cs" Inherits="LandfillServices.UI.Web.UI.BrokerPassageProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Broker passage Edit </h5>
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
                            <asp:Panel runat="server" ID="PanelControlsValues" Visible="false">
                                <div class="col-lg-12">
                                    <div class="alert alert-warning">
                                        <a href="#" class="close" data-dismiss="alert">&times;</a>
                                        <strong></strong>The contract broker and weight is required
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">

                                <label class="col-lg-4 control-label">Contract broker</label>
                                <div class="col-lg-2">
                                    <asp:DropDownList ID="DropDownListContractBroker" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <label class="col-lg-4 control-label">Date </label>
                                <div class="col-lg-2">
                                    <asp:Label ID="LabelDate" name="Date" runat="server" CssClass="form-control"></asp:Label>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-lg-4 control-label">Product</label>
                                <div class="col-lg-2">
                                    <asp:DropDownList ID="DropDownListProduct" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <label class="col-lg-4 control-label">Weight (Kg)</label>
                                <div class="col-lg-2">
                                    <asp:TextBox ID="TextBoxWeight" name="Weight" runat="server" placeholder="Weight" CssClass="form-control"></asp:TextBox>

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
