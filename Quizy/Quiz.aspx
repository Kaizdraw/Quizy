<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Quizy.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; font-size: xx-large">
    
        Pytanie
        <asp:Label ID="NrPytania" runat="server">0</asp:Label>
    
    </div>
        Ilość dobrych odpowiedzi:
        <asp:Label ID="Wynik" runat="server" Text="0"></asp:Label>
        <br />
        <asp:Label ID="Pytanie" runat="server" style="text-align: center"></asp:Label>
        <asp:RadioButtonList ID="Odpowiedzi" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Potwierdz" runat="server" Text="Potwierdź odpowiedź" Height="30px" OnClick="Potwierdz_Click" Width="200px" />
        <asp:Label ID="Zaznblad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Pytanie stworzone przez:
        <asp:Label ID="Nick" runat="server"></asp:Label>
    </form>
</body>
</html>
