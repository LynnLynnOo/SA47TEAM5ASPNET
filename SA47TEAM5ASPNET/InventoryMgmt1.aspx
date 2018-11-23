<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventoryMgmt1.aspx.cs" Inherits="SA47TEAM5ASPNET.InventoryMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .grdContent {
            width: 80%;
            border: solid 2px black;
            /*min-width: 80%;*/
        }

        .header {
            background-color: #04488a;
            font-family: Arial;
            color: White;
            border: none 0px transparent;
            height: 25px;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 14px;
            color: #000;
            min-height: 25px;
            /*text-align: center;*/
            border: none 0px transparent;
        }

            .rows:hover {
                background-color: lightyellow;
                font-family: Arial;
                color: black;
                /*text-align: center;*/
            }

        .selectedrow {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }

        .mydatagrid a {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

        .mygrdContent span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/ {
            background-color: #c9c9c9;
            color: #000;
            /*padding: 5px 5px 5px 5px;*/
        }



        .InventoryPage {
            margin-top: 50px;
            margin-left: 50px;
        }

        .auto-style1 {
            position: absolute;
            top: 127px;
            left: 572px;
            z-index: 1;
        }
    </style>

    <div class="InventoryPage">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:DropDownList ID="optionDropDownList" runat="server">
                <asp:ListItem>Title</asp:ListItem>
                <asp:ListItem>Category</asp:ListItem>
                <asp:ListItem>ISBN</asp:ListItem>
                <asp:ListItem>Author</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="optionTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" OnClick="Button1_Click" Text="Search" />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Create New Book" />
        </asp:Panel>
    </div>


    <div class="InventoryPage">
        <asp:GridView CssClass="grdContent" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating">
            <HeaderStyle HorizontalAlign="Center" BackColor="#6699FF" ForeColor="#FFFFFF" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="1600px" HeaderText="Title">
                    <HeaderStyle CssClass="header" />

                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control mr-sm-2" ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" HeaderText="Author">
                    <HeaderStyle CssClass="header" />

                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control mr-sm-2" ID="TextBox2" runat="server" Text='<%# Bind("Author") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Author") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px" HeaderText="ISBN">
                    <HeaderStyle CssClass="header" />

                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control mr-sm-2" ID="TextBox3" runat="server" Text='<%# Bind("ISBN") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ISBN") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px" HeaderText="Price">
                    <HeaderStyle CssClass="header" />

                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control mr-sm-2" ID="TextBox4" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="250px" HeaderText="Stock">
                    <HeaderStyle CssClass="header" />
                    <EditItemTemplate>
                        <asp:TextBox CssClass="form-control mr-sm-2" ID="TextBox5" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                    </EditItemTemplate>

                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Stock") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" HeaderText="Cover" SortExpression="Cover">
                    <HeaderStyle CssClass="header" />
                    <ItemTemplate>
                        <image src="images/<%# Eval("Image") %>" width="90" height="100"></image>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300px" HeaderText="Controls" ShowHeader="False">
                    <HeaderStyle CssClass="header" />
                    <EditItemTemplate>

                        <asp:Button Style="margin-top: 10px" CssClass="btn btn-info" ID="Button1" Width="100px" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                        <br />
                        <asp:Button Style="margin-top: 10px" CssClass="btn btn-info" ID="Button2" Width="100px" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button Style="margin-top: 10px" CssClass="btn btn-info" ID="Button1" Width="100px" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <HeaderStyle CssClass="header"></HeaderStyle>

            <PagerStyle CssClass="pager"></PagerStyle>

            <RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>

    </div>

</asp:Content>
