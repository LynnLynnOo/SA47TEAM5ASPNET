<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SA47TEAM5ASPNET.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMsg" Text="text" runat="server" />
    <div>
        <h1 class="text-center">Cart</h1>
    </div>
    <div>
        <asp:Panel ID="pnlError" runat="server" Width="100%" Visible="false" HorizontalAlign="Center">
            <div class="alert alert-dismissible alert-success">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <strong>Ooops! Your quantity exceeds our stock. Please reduce your quantity or select another item.</strong>
            </div>
        </asp:Panel>
    </div>

    <div class="row">
        <div class="col-lg-12">

            <asp:GridView ID="gvCart" runat="server" CssClass="Grid table table-striped" AutoGenerateColumns="False" GridLines="None">
                <HeaderStyle HorizontalAlign="Center" BackColor="#6699FF" ForeColor="#FFFFFF" />
                <AlternatingRowStyle BackColor="#F8F8F8" />

                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:c}" />

                    <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnMinus" runat="server" CssClass="btn btn-info" OnClick="btnMinus_Click" CausesValidation="false">-</asp:LinkButton>
                            &nbsp;  &nbsp;                              
                            <asp:Label ID="lblQty" CssClass="text-dark" runat="server" Text='<%# Eval("Qty") %>' />
                            &nbsp; &nbsp;
                            <asp:LinkButton ID="btnPlus" runat="server" CssClass="btn btn-info" OnClick="btnPlus_Click" CausesValidation="false">+</asp:LinkButton>


                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle Width="140px" HorizontalAlign="Center" />
                    </asp:TemplateField>





                    <asp:BoundField DataField="Discount" HeaderText="Discount" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:c}" />
                </Columns>
            </asp:GridView>
            <br />



            <asp:Panel ID="pnlPromoCode" runat="server" HorizontalAlign="Right" Visible="False">
                <asp:Label ID="lblPromoCode" Text="Invalid Code!" runat="server" CssClass="form-inline" />
            </asp:Panel>
            <asp:Panel runat="server" CssClass="form-inline" HorizontalAlign="Right">

                <asp:Button ID="btnDiscount" CssClass="btn btn-secondary my-2 my-sm-0" type="submit" OnClick="btnDiscount_Click" Text="Submit" runat="server" />
                <asp:TextBox runat="server" ID="txtDiscount" CssClass="form-control mr-sm-2" placeholder="Discount" />
            </asp:Panel>



            <br />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="500"></asp:Timer>
            
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
                                <th style="text-align: right" scope="col"><%=Session["discountTotal"].ToString() %>&nbsp;&nbsp;&nbsp;</th>
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
            </ContentTemplate>
            </asp:updatepanel>
            <br />

            <div class="container">
                <div class="row">
                    <div class="col-md-2 col-sm-12">
                        <asp:Button ID="btnContinueShopping" runat="server" Text="Continue Shopping" OnClick="Products" CssClass="btn btn-warning float-right" />

                    </div>
                    <div class="col-md-8"></div>
                    <div class="col-md-2 col-sm-12">
                        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="Checkout" CssClass="btn btn-primary float-left" />

                    </div>
                </div>
            </div>
            <br />

        </div>
    </div>
</asp:Content>
