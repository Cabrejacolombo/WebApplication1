<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MembersOnly.aspx.cs" Inherits="WebApplication1.Account.MembersOnly" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="Label1" runat="server" Text="Nivel Actual: "></asp:Label>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="getTemp1" TypeName="WebApplication1.Data">
    </asp:ObjectDataSource>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="5000" ontick="Timer1_Tick1">
            </asp:Timer>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="ObjectDataSource1" 
                Width="708px">
                <series>
                    <asp:Series ChartType="Line" Name="Series1" XValueMember="time" 
                        XValueType="Time" YValueMembers="temp">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>

