<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseHistory.aspx.cs" Inherits="SA47TEAM5ASPNET.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <br />
        <asp:GridView ID="orderDetailsgdv" runat="server" AutoGenerateColumns="False" DataKeyNames="InvoiceID" Height="165px" Width="1075px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="InvoiceID" HeaderText="InvoiceID" ReadOnly="True" SortExpression="InvoiceID" />
                <asp:BoundField DataField="InvoiceDate" HeaderText="InvoiceDate" SortExpression="InvoiceDate" DataFormatString="{0:dd MMMM yyyy}" />
                <asp:BoundField DataField="PromoCode" HeaderText="PromoCode" SortExpression="PromoCode" />
                <asp:BoundField DataField="PromoAmt" DataFormatString="{0:c}" HeaderText="PromoAmt" SortExpression="PromoAmt" />
                <asp:BoundField DataField="InvoiceAmt" DataFormatString="{0:c}" HeaderText="InvoiceAmt" SortExpression="InvoiceAmt" />
                <asp:BoundField DataField="PaymentStatus" HeaderText="PaymentStatus" SortExpression="PaymentStatus" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
