<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SA47TEAM5ASPNET.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>

    <div class="defaultSearch">
        <link href="Content/bootstrap-cerulean.css" rel="stylesheet">
            <div class="dropdownlist1">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>
            <div class="SearchTextBox">
                <asp:TextBox runat="server" class="form-control form-control-sm" ID="SearchTextBox" type="text"></asp:TextBox>
            </div>
            <div class="SearchButton">
                <asp:Button ID="SearchButton" class="btn" runat="server" Text="Search" OnClick="SearchButton_Click" />
            </div>
    </div>

    <div class="defaultcontainer">
        <asp:Panel ID="defaultcontainer" runat="server">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <link href="Content/StyleSheet.css" rel="stylesheet">
                    <div class="col-xs-12 col-sm-6 col-md-3">
                        <div class="assigndimension">
                            <div class="bookimge">
                                <a href="BookDetails.aspx?ISBN=<%# Eval("ISBN") %>">
                                    <image src="images/<%# Eval("Image") %>" width="218" height="218"></image>
                            </div>
                            <div class="booktitles">
                                <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("BookId") %>' />
                                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                            </div>
                            <div class="bookcategory">
                                Category:<asp:Label ID="CategoryLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                            </div>
                            <div class="authorname">
                                Author:<asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>' />
                            </div>
                            <div class="price">
                                <div class="plabel1">
                                    Price:<asp:Label ID="PriceLabel1" runat="server" Text='<%# Eval("Price") %>' />
                                </div>
                                <div class="plabel2">
                                    <asp:Label ID="PriceLabel2" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>

                </ItemTemplate>
            </asp:ListView>
        </asp:Panel>

    </div>
</asp:Content>
