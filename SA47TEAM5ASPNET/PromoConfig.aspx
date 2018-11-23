<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromoConfig.aspx.cs" Inherits="SA47TEAM5ASPNET.PromoConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Configuration</h1>
    </div>

    <link href="Content/bootstrap-cerulean.css" rel="stylesheet" />
    <div class="hidari">
    <h2>Promotion</h2>
    <asp:Panel ID="PromotionPanel" runat="server" BorderStyle="Solid" CssClass="PanelPadding" BorderColor="#F4F4F4" BorderWidth="1px">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional"><ContentTemplate>   
    <table>
        <tr><td style="vertical-align:top", "width: 111px; height: 20px;">Promo Code:</td><td style="height: 40px" >
            <asp:TextBox ID="PromoTB" runat="server" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PromoTB" Display="None" ErrorMessage="Please enter a valid Promo Code" ValidationGroup="1"></asp:RequiredFieldValidator>
            <br />
            <br />
            </td></tr>
   
            <tr><td style="vertical-align:top","width: 111px">Valid Start Date:</td><td>
            <asp:Calendar ID="ValidSCal" runat="server" OnSelectionChanged="ValidSCal_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="PCalVal" runat="server" Height="0px" Width="0px" BorderStyle="None" ReadOnly="True" ValidationGroup="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PCalVal" Display="None" ErrorMessage="Please select a start date!" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <br />
            </td></tr>
                <tr><td style="vertical-align:top","width: 111px">Discount Amount:</td><td>
            <asp:TextBox ID="PromoDisc" runat="server" ValidationGroup="1"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="PromoDisc" Display="None" ErrorMessage="Please enter a valid Discount Amount" MaximumValue="100" MinimumValue="1" Type="Integer" ValidationGroup="1"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PromoDisc" Display="None" ErrorMessage="Please enter a valid Discount Amount" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <br />
                    <br />
            </td></tr>
                <tr><td style="vertical-align:top","width: 111px">Promo Duration:</td><td>
            <asp:TextBox ID="PromoDur" runat="server" ValidationGroup="1"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="PromoDur" Display="None" ErrorMessage="Please enter a valid Promo Duration" MaximumValue="4000" MinimumValue="1" Type="Integer" ValidationGroup="1"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PromoDur" Display="None" ErrorMessage="Please enter a valid Promo Duration" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:Button style="position:relative; float: right; margin-left:110px;" ID="AddPromo" runat="server" OnClick="AddPromo_Click" Text="Add New Promo" ValidationGroup="1" />
                    <br />
                    <br />
            </td></tr>

    </table>        

        <p>
            &nbsp;</p>
            <p>
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </p>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="AddPromo" />
        </Triggers>
        </asp:UpdatePanel>
            
    

        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="1" />
         </asp:Panel>   
    

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <asp:Button ID="PromoAmend" runat="server" OnClick="PromoAmend_Click" Text="Amend Promos" />
        <br />
        <br />
        <asp:GridView ID="PromoGridView" runat="server" AutoGenerateColumns="False" Visible="False" OnRowCancelingEdit="PromoGridView_RowCancelingEdit" OnRowEditing="EdGV1" OnRowUpdating="UpGV1" Width="514px">
            <Columns>
                <asp:TemplateField HeaderText="Promo Code" SortExpression="PromoCode">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PromoCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Discount") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Promo Start Date" SortExpression="ValidStart">
                    <EditItemTemplate>
                        <asp:Calendar ID="Calendar3" runat="server" VisibleDate='<%# Bind("ValidStart") %>' SelectedDate='<%# Bind("ValidStart") %>'></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ValidStart", "{0:dd MMMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Promo Duration" SortExpression="PromoDuration">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PromoDuration") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("PromoDuration") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label7" runat="server"></asp:Label>
        <br />             
        <br />
        </ContentTemplate>
        
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="PromoAmend" />
    </Triggers>
        
</asp:UpdatePanel>
        
        </div>


    <div class="migi">
    <h2>Discounts
            </h2>    
    <asp:Panel ID="PanelDiscount" runat="server" BorderStyle="Solid" CssClass="PanelPadding" BorderColor="#F4F4F4" BorderWidth="1px">   
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <table>
        <tr><td style="vertical-align:top">Discount ID:</td><td>
            <asp:TextBox ID="DiscIDTB" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DiscIDTB" Display="None" ErrorMessage="Please input a valid ID" ValidationGroup="2"></asp:RequiredFieldValidator>
            <br />
            <br />
            </td></tr>
                <tr><td style="vertical-align:top">Valid Start Date:</td><td>
            <asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged"></asp:Calendar>
                    <asp:TextBox ID="DCalVal" runat="server" BorderStyle="None" Height="0px" ReadOnly="True" ValidationGroup="2" Width="0px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DCalVal" Display="None" ErrorMessage="Please select a date" ValidationGroup="2"></asp:RequiredFieldValidator>
                    <br />
            </td></tr>
                <tr><td style="vertical-align:top">Discount Amount:</td><td>
            <asp:TextBox ID="CatDisAmt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CatDisAmt" Display="None" ErrorMessage="Please input a valid discount amount" ValidationGroup="2"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="CatDisAmt" Display="None" ErrorMessage="Please enter a number from 1 to 100" MaximumValue="99" MinimumValue="1" ValidationGroup="2"></asp:RangeValidator>
                    <br />
                    <br />
            </td></tr>
                <tr><td style="vertical-align:top">Discount Duration:</td><td>
            <asp:TextBox ID="DisDur" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DisDur" Display="None" ErrorMessage="Please input a valid duration" ValidationGroup="2"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="DisDur" Display="None" ErrorMessage="Please enter a valid Discount Duration" ValidationGroup="2" MaximumValue="900" MinimumValue="1"></asp:RangeValidator>
                    <br />
                    <br />
            </td></tr>
            <tr><td style="vertical-align:top">Category:</td><td>
            <asp:DropDownList ID="CategoryDDL" runat="server" ></asp:DropDownList>
                                   
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="CategoryDDL" Display="None" ErrorMessage="Please select a valid Category" ValidationGroup="2"></asp:RequiredFieldValidator>
                                   
                <asp:Button ID="AddDiscount" style="position:relative; float: right; margin-left:200px;" runat="server" OnClick="AddDiscount_Click" Text="Add New Discount" ValidationGroup="2" />
                                   
            </td></tr>


    </table>  
              <p>
                  &nbsp;</p>
           <p> <asp:Label ID="DiscLabel" runat="server"></asp:Label></p>
        </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="AddDiscount" EventName="Click" />
                  <asp:AsyncPostBackTrigger ControlID="DiscountGridView" EventName="RowUpdating" />
            </Triggers>
              </asp:UpdatePanel>
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="2" />
    </asp:Panel> 
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" AutoGenerateColumn ="False">
        <ContentTemplate>
            <asp:Button ID="DiscountAmend" runat="server" OnClick="DiscountAmend_Click" Text="Amend Discounts" />
            <br />
            <br />
            <asp:GridView ID="DiscountGridView" runat="server" AutoGenerateColumns="False" Visible="False" OnRowCancelingEdit="DiscountGridView_RowCancelingEdit" OnRowEditing="DiscountGridView_RowEditing" OnRowUpdating="DiscountGridView_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Discount ID" SortExpression="DiscountID">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DiscountID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount" SortExpression="DiscountAmt">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DiscountAmt") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DiscountAmt") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount Start Date" SortExpression="ValidStart">
                    <EditItemTemplate>
                        <asp:Calendar ID="Calendar3" runat="server" VisibleDate='<%# Bind("ValidStart") %>' SelectedDate='<%# Bind("ValidStart") %>'></asp:Calendar>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ValidStart", "{0:dd MMMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount Duration" SortExpression="DiscountDuration">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DiscountDuration") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DiscountDuration") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category ID" SortExpression="CategoryID">
                    <EditItemTemplate>
                        <asp:Textbox ID="DDL5" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("CategoryID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <br />
            <br />
           
        </ContentTemplate>
    </asp:UpdatePanel>
        
        </div>

</asp:Content>

