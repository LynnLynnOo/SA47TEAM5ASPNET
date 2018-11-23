<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="SA47TEAM5ASPNET.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMsg" Text="text" runat="server" />
    <div>
        <h1 class="text-center">Thank You</h1>
    </div>
    <div class="row">
        <div class="col-lg-12">

            <asp:GridView ID="gvCart" runat="server" CssClass="Grid table table-striped" AutoGenerateColumns="False" GridLines="None">
                <HeaderStyle HorizontalAlign="Center" BackColor="#6699FF" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />

                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Qty" HeaderText="Qty" />

                    <asp:BoundField DataField="Discount" HeaderText="Discount" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:c}" />
                </Columns>
            </asp:GridView>
            <br />



            <br />
            <div>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th style="text-align: left" scope="col">Total before discount</th>
                            <th style="text-align: right" scope="col"><%=Session["total"].ToString() %>&nbsp;&nbsp;&nbsp;</th>
                            <th></th>
                        </tr>
                        <tr>
                            <th style="text-align: left" scope="col">Discount</th>
                            <th style="text-align: right" scope="col"><%=Session["discountTotal"] %>&nbsp;&nbsp;&nbsp;</th>
                            <th></th>
                        </tr>
                        <tr>
                            <th style="text-align: left" scope="col">Total after discount</th>
                            <th style="text-align: right" scope="col"><%=Session["discountedTotal"].ToString() %>&nbsp;&nbsp;&nbsp;</th>
                            <th></th>
                        </tr>
                    </thead>

                </table>
            </div>
            <br />

            <br />

        </div>
    </div>
</asp:Content>
