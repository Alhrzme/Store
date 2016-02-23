<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="WebsiteTraffic.aspx.cs" Inherits="Store.Pages.Admin.WebsiteTraffic" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
        Посещаемость сайта
    </div>
    <div class="graph">
        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series ChartType="SplineArea" Name="Series1" YValuesPerPoint="6">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <div class="visitersPerDay">
            За текущий день сайт посетили <%=GetSiteVisitorsPerDay() %>.
        </div>
    </div>
</asp:Content>
