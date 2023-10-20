<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TesteIntegracaoBD.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="css/index.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="Form" runat="server">
        <main>
            <nav class="menu">
                <a class="l1" href="index.aspx">Produtos</a>
                <a href="novo.aspx">Novo</a>
            </nav>
            <table class="tabela_produtos">
                <tr>
                    <th>CD</th>
                    <th>Nome</th>
                    <th>Valor (R$)</th>
                    <th></th>
                </tr>
                <asp:Literal ID="litTabela" runat="server"></asp:Literal>    
            </table>
        </main>
    </form>
</body>
</html>
