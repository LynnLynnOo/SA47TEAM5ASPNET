<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InventoryMgmt2.aspx.cs" Inherits="SA47TEAM5ASPNET.InventoryMgmt2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .textbox {
            width: 200px;
            height: 27px;
            left: 438px;
        }

        .dropdown {
            width: 200px;
            height: 27px;
            left: 438px;
        }

        .button {
            width: 60px;
            height: 27px;
        }

        .txtboxlabel {
            left: 332px;
        }

        .requiredfield {
            left: 673px;
        }

        .auto-style1 {
            z-index: 1;
            position: absolute;
            top: 519px;
            left: 33px;
        }

        .auto-style3 {
            z-index: 1;
            width: 277px;
            height: 27px;
            position: absolute;
            top: 460px;
            left: 32px;
        }

        .auto-style4 {
            z-index: 1;
            position: absolute;
            top: 196px;
            left: 32px;
            width: 278px;
            height: 234px;
        }

        .auto-style5 {
            z-index: 1;
            position: absolute;
            top: 98px;
            left: 191px;
            width: 594px;
        }

        .auto-style6 {
            left: 672px;
            z-index: 1;
            position: absolute;
            top: 401px;
        }

        .auto-style8 {
            width: 857px;
            height: 579px;
            position: absolute;
            top: -8px;
            left: 268px;
            z-index: 1;
        }
    .auto-style9 {
        width: 200px;
        height: 27px;
        left: 438px;
        z-index: 1;
        position: absolute;
        top: 398px;
    }
    .auto-style10 {
        left: 331px;
        z-index: 1;
        position: absolute;
        top: 457px;
        height: 21px;
    }
        .auto-style12 {
            width: 59px;
            height: 27px;
            z-index: 1;
            position: absolute;
            top: 519px;
            left: 624px;
        }
        </style>

    <p>
        <br />
    </p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
    <p>
    </p>
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style8">

        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
            <asp:Label CssClass="txtboxlabel" ID="Label1" runat="server" Style="z-index: 1; position: absolute; top: 174px" Text="Title"></asp:Label>
            <asp:Label ID="Label7" runat="server" Font-Size="Larger" Text="New Book Registration" CssClass="auto-style5"></asp:Label>
        </p>
        <p>
            <asp:TextBox CssClass="textbox" ID="titleTextBox" runat="server" Style="z-index: 1; position: absolute; top: 174px"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="requiredfield" ID="RequiredFieldValidator1" runat="server" ControlToValidate="titleTextBox" ErrorMessage="Title cannot be blank!" ForeColor="Red" Style="z-index: 1; position: absolute; top: 178px"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:DropDownList CssClass="dropdown" ID="catDropDownList" runat="server" Style="z-index: 1; position: absolute; top: 225px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:TextBox CssClass="textbox" ID="isbnTextBox" runat="server" Style="z-index: 1; position: absolute; top: 281px"></asp:TextBox>
            <asp:Label CssClass="txtboxlabel" ID="Label2" runat="server" Style="z-index: 1; position: absolute; top: 224px" Text="Category"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style3" />
        </p>
        <p>
            <asp:RequiredFieldValidator CssClass="requiredfield" ID="RequiredFieldValidator2" runat="server" ControlToValidate="isbnTextBox" ErrorMessage="ISBN cannot be blank!" ForeColor="Red" Style="z-index: 1; position: absolute; top: 281px"></asp:RequiredFieldValidator>
        </p>


        <p>
            &nbsp;
        </p>
        <p>
            <asp:Label CssClass="txtboxlabel" ID="Label3" runat="server" Style="z-index: 1; position: absolute; top: 281px" Text="ISBN"></asp:Label>
            <asp:Label CssClass="txtboxlabel" ID="Label4" runat="server" Style="z-index: 1; position: absolute; top: 342px" Text="Author"></asp:Label>
            <asp:Image ID="Image1" runat="server" CssClass="auto-style4" AlternateText="Book Cover." BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ForeColor="#CCCCCC" />
        </p>
        <p>
            <asp:RequiredFieldValidator CssClass="requiredfield" ID="RequiredFieldValidator3" runat="server" ControlToValidate="authorTextBox" ErrorMessage="Author cannot be blank!" ForeColor="Red" Style="z-index: 1; position: absolute; top: 342px"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:TextBox CssClass="textbox" ID="authorTextBox" runat="server" Style="z-index: 1; position: absolute; top: 342px"></asp:TextBox>
            <asp:Label CssClass="txtboxlabel" ID="Label5" runat="server" Style="z-index: 1; position: absolute; top: 397px" Text="Stock"></asp:Label>
        </p>
        <p>
            <asp:TextBox CssClass="auto-style9" ID="stockTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="auto-style6" ID="RequiredFieldValidator4" runat="server" ControlToValidate="stockTextBox" ErrorMessage="Stock Qty cannot be blank!" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button CssClass="auto-style12" ID="backButton" runat="server" Text="Cancel" Style="z-index: 1; position: absolute; top: 520px; left: 600px; width: 59px;" CausesValidation="false" OnClick="backButton_Click"/>
        </p>
        <p>
            <asp:Label CssClass="auto-style10" ID="Label6" runat="server" Text="Price"></asp:Label>
        </p>
        <p>
            <asp:TextBox CssClass="textbox" ID="priceTextBox" runat="server" Style="z-index: 1; position: absolute; top: 458px"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="requiredfield" ID="RequiredFieldValidator5" runat="server" ControlToValidate="priceTextBox" ErrorMessage="Price cannot be blank!" ForeColor="Red" Style="z-index: 1; position: absolute; top: 458px"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="uploadLabel" runat="server" Text="Label" CssClass="auto-style1"></asp:Label>
        </p>
        <p>
            <asp:Button CssClass="button" ID="saveButton" runat="server" Style="z-index: 1; position: absolute; top: 520px; left: 440px; width: 59px;" Text="Save" OnClick="saveButton_Click" />
            <asp:Button CssClass="button" ID="resetButton" runat="server" Style="z-index: 1; position: absolute; top: 520px; left: 520px; width: 59px;" Text="Reset" OnClick="cancelButton_Click" CausesValidation="false" />
        </p>
        <p>
            &nbsp;</p>
    </asp:Panel>
</asp:Content>
