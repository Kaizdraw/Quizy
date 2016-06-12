<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tworzenie_zestawu.aspx.cs" Inherits="Quizy.Tworzenie_zestawu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; font-size: xx-large">
    
        Tworzenie zestawu</div>
        <asp:Label ID="Pytblad" runat="server" ForeColor="Red"></asp:Label>
        <asp:CheckBoxList ID="Pytania" runat="server">
        </asp:CheckBoxList>
        Nazwa zestawu:<br />
        <asp:TextBox ID="Zestaw" runat="server"></asp:TextBox>
        <asp:Label ID="Zestawblad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Nazwa Użytkownika:<br />
        <asp:TextBox ID="Nick" runat="server"></asp:TextBox>
        <asp:Label ID="Nickblad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="Potwierdz" runat="server" Height="30px" OnClick="Potwierdz_Click" Text="Potwierdź" Width="100px" />
        <asp:Button ID="Cofnij" runat="server" Height="30px" OnClick="Cofnij_Click" Text="Cofnij" Width="100px" />
    </form>
</body>
</html>