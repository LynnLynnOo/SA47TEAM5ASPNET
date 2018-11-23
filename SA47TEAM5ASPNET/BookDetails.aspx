<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="SA47TEAM5ASPNET.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link href="Content/StyleSheet.css" rel="stylesheet" /> 
    <asp:Panel ID="DetailsPanel" runat="server" HorizontalAlign="Center" >
        <div class="bookdetailsimg">
            <asp:Image style="align-items:center" ID="Image1" runat="server" Width="20%" Height="20%"/>
     </div>
        <div>
           <div>
            <table class="center" style="empty-cells: hide; position: relative; width: 300px; text-align: left; text-indent: inherit;">
        <tr><td style="align-content:flex-end">Title: </td><td>
             <asp:Label ID="Title_lbl" runat="server" Text="Label"></asp:Label>
            </td></tr>
        <tr><td style="align-content:flex-end">Author: </td><td>
            <asp:Label ID="Author_lbl" runat="server" Text="Label"></asp:Label></td></tr>
        <tr><td style="align-content:flex-end">Category: </td><td>
             <asp:Label ID="Category_lbl" runat="server" Text="Label"></asp:Label>
            </td></tr>
        <tr><td style="align-content:flex-end">Price: </td><td>
             <asp:Label ID="NormalPrice_lbl" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Discounted_lbl" runat="server" Text="Label"></asp:Label>
            </td></tr>
    </table>
        </div>
    <div>
                                    
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                <ContentTemplate>
                    <asp:Button ID="Minus_btn" runat="server" Text="-" OnClick="Minus_Click" />
           <asp:TextBox ID="TextBox1" runat="server" Width="18px">0</asp:TextBox>
        <asp:Button ID="Plus_btn" runat="server" Text="+" OnClick="Plus_Click" />
                    &nbsp;<asp:Button ID="AddtoCart_btn" runat="server" OnClick="AddtoCart_Click" Text="Add" Width="75px" />
                </ContentTemplate>
            </asp:UpdatePanel>
       </div>
    <div>
         <asp:Label ID="Warning_lbl" runat="server" Text="Label"></asp:Label>
    </div>
            </div>
        </asp:Panel>
</asp:Content>
