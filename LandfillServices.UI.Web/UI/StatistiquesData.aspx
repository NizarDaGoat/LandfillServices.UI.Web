<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatistiquesData.aspx.cs" Inherits="LandfillServices.UI.Web.UI.StatistiquesData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-lg-4">
                <div class="ibox ">
                    <div class="ibox-title">
                        <div class="ibox-tools">
                            <span class="label label-success float-right">Current Month</span>
                        </div>
                        <h5>Total Weight Aluminum</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"><%=TotalWeightAliminum%></h1>
                        <div class="stat-percent font-bold text-success"><%=PercentAliminum%>% <i class="fa fa-bolt"></i></div>
                        <small>compared to total</small>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="ibox ">
                    <div class="ibox-title">
                        <div class="ibox-tools">
                            <span class="label label-info float-right">Current Month</span>
                        </div>
                        <h5>Total Weight Metal</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"><%=TotalWeightMetal%></h1>
                        <div class="stat-percent font-bold text-success"><%=PercentMetal%>% <i class="fa fa-bolt"></i></div>
                        <small>compared to total</small>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="ibox ">
                    <div class="ibox-title">
                        <div class="ibox-tools">
                            <span class="label label-warning float-right">Current Month</span>
                        </div>
                        <h5>Total Weight Paper</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"><%=TotalWeightPaper%></h1>
                        <div class="stat-percent font-bold text-success"><%=PercentPaper%>% <i class="fa fa-bolt"></i></div>
                        <small>compared to total</small>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-4">
                <div class="ibox ">
                    <div class="ibox-title">
                        <div class="ibox-tools">
                            <span class="label label-warning float-right">Current Month</span>
                        </div>
                        <h5>Total Weight Electronics</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"><%=TotalWeightElectronics%></h1>
                        <div class="stat-percent font-bold text-success"><%=PercentElectronics%>% <i class="fa fa-bolt"></i></div>
                        <small>compared to total</small>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="ibox ">
                    <div class="ibox-title">
                        <div class="ibox-tools">
                            <span class="label label-success float-right">Current Month</span>
                        </div>
                        <h5>Total Weight Glass</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"><%=TotalWeightGlass%></h1>
                        <div class="stat-percent font-bold text-success"><%=PercentGlass%>% <i class="fa fa-bolt"></i></div>
                        <small>compared to total</small>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="ibox ">
                    <div class="ibox-title">
                        <div class="ibox-tools">
                            <span class="label label-info float-right">Current Month</span>
                        </div>
                        <h5>Total Weight Plastics</h5>
                    </div>
                    <div class="ibox-content">
                        <h1 class="no-margins"><%=TotalWeightPlastics%></h1>
                        <div class="stat-percent font-bold text-success"><%=PercentPlastics%>% <i class="fa fa-bolt"></i></div>
                        <small>compared to total</small>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <div class="ibox">
                    <div class="ibox-content">
                        <h5>BROKERS : progression of expenses</h5>
                        <h2><%=FormattedTotalAmountObjectveBroker%></h2>
                        <div class="progress progress-mini">
                            <div style="width: <%=FormattedTotalAmountObjectveBroker%>%;" class="progress-bar"></div>
                        </div>

                        <div class="m-t-sm small">Date of data collection at : <%=FormattedDateNow%></div>
                    </div>
                </div>
            </div>


            <div class="col-lg-6">
                <div class="ibox">
                    <div class="ibox-content">
                        <h5>LOGISTICS : progression of expenses</h5>
                        <h2><%=FormattedTotalAmountObjectveLogistic%></h2>
                        <div class="progress progress-mini">
                            <div style="width: <%=FormattedTotalAmountObjectveLogistic%>%;" class="progress-bar-danger"></div>
                        </div>

                        <div class="m-t-sm small">Date of data collection at : <%=FormattedDateNow%></div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
