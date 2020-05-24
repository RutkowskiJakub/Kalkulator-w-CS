<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="kalkulator.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="X: "></asp:Label>
            <asp:TextBox ID="TextBoxWartosc1" runat="server" OnTextChanged="TextBoxWartosc1_TextChanged"></asp:TextBox>   
            <br />
            <asp:Label ID="Label2" runat="server" Text="Y: "></asp:Label>
            <asp:TextBox ID="TextBoxWartosc2" runat="server" OnTextChanged="TextBoxWartosc2_TextChanged"></asp:TextBox> 
            <br />
            <asp:Label ID="Label3" runat="server" Text="Operacja: "></asp:Label>
            <asp:DropDownList ID="DropDownListDzialanie" runat="server" OnSelectedIndexChanged="DropDownListDzialanie_SelectedIndexChanged">
                <asp:ListItem Value="+">+</asp:ListItem>
                <asp:ListItem Value="-">-</asp:ListItem>
                <asp:ListItem Value="*">*</asp:ListItem>
                <asp:ListItem Value="/">/</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Licz" OnClick="Button1_Click" />
            <asp:TextBox ID="TextBoxWynik" runat="server"></asp:TextBox>
        </div>
    </form>
   
</body>
</html>
