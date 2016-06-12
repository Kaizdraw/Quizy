<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tworzenie_pytania.aspx.cs" Inherits="Quizy.Tworzenie_pytania" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; font-size: xx-large">
    
        Tworzenie pytania</div>
        Nazwa użytkownika:<br />
        <asp:TextBox ID="Nick" runat="server"></asp:TextBox>
        <asp:Label ID="Nickblad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Pytanie:<br />
        <asp:TextBox ID="Pytanie" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="Pytanieblad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Odpowiedź poprwana:<br />
        <asp:TextBox ID="OdpPop" runat="server"></asp:TextBox>
        <asp:Label ID="OdpPopblad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Odpowiedź błędna:<br />
        <asp:TextBox ID="OdpBl1" runat="server"></asp:TextBox>
        <asp:Label ID="OdpBl1blad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Odpowiedź błędna:<br />
        <asp:TextBox ID="OdpBl2" runat="server"></asp:TextBox>
        <asp:Label ID="OdpBl2blad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Odpowiedź błędna:<br />
        <asp:TextBox ID="OdpBl3" runat="server"></asp:TextBox>
        <asp:Label ID="OdpBl3blad" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="Zatwierz" runat="server" Text="Zatwierdź pytanie" OnClick="Zatwierz_Click" Height="30px" Width="150px" />
        <asp:Button ID="Cofnij" runat="server" Text="Cofnij" OnClick="Cofnij_Click" Height="30px" Width="100px" />
    </form>
</body>
</html>
