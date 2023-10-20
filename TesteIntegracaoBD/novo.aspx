<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="novo.aspx.cs" Inherits="TesteIntegracaoBD.novo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="css/Novo.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
        <nav class="menu">
          <a href="index.aspx">Produtos</a>
          <a class="l2" href="novo.aspx">Novo</a>
        </nav>

        <div class="formulario">
            <div class="lbltxtNome">
                <asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label>
                <asp:TextBox ID="txtnome" runat="server"></asp:TextBox>
            </div>


        <div class="Numericos">
            <div class="lbltxtCodigo">
                <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
                <asp:TextBox ID="txtcodiogo" runat="server"></asp:TextBox>
            </div>
            <div class="lbltxtValor">
                <asp:Label ID="Label3" runat="server" Text="Valor:"></asp:Label>
                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        <asp:Label ID="lblSpam" runat="server" Text=""></asp:Label>
        </div>

        </main>

    </form>
</body>
</html>
