<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Quizy._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: xx-large; text-align: center">
    
        Quizy i testy</div>
        <asp:Label ID="Info" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Rozpocznij_quizy" runat="server" Text="Rozpocznij quiz" OnClick="Rozpocznij_quizy_Click" Height="30px" Width="150px" />
        <asp:DropDownList ID="Lista_quizow" runat="server" Height="30px" Width="150px">
            <asp:ListItem>Wszystkie pytania</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="StworzPytanie" runat="server" OnClick="StworzPytanie_Click" Text="Stwórz pytanie" Height="30px" Width="150px" />
        <br />
        <asp:Button ID="Stworz_zestaw" runat="server" Height="30px" OnClick="Stworz_zestaw_Click" Text="Stwórz zestaw" Width="150px" />
    </form>
</body>
</html>
