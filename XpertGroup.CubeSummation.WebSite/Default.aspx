<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XpertGroup.CubeSummation.WebSite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h4>Configuración</h4>
        <asp:Label ID="lblTestCases" runat="server"></asp:Label>
        <p><br /></p>
        <asp:Label ID="lblNumberOperations" runat="server"></asp:Label>
        <p><br /></p>
        <asp:Label ID="lblNumberOperationsExecuted" runat="server"></asp:Label>
    </div>

    <div class="jumbotron">
        <h4>Lineas de Entrada</h4>
        <asp:TextBox ID="txtInputCode" runat="server" AutoComplete="false"></asp:TextBox>
        <asp:Button ID="btnSendCode" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnSendCode_Click" />
    </div>

    <div class="jumbotron">
        <h4>Salida del aplicativo para la entrada: <asp:Label ID="lblCurrentInput" runat="server"></asp:Label></h4>
        <asp:TextBox ID="txtOutputCode" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
    </div>

     <div class="jumbotron">
        <h4>Errores de Validación</h4>
        <asp:TextBox ID="txtValidationErrors" runat="server" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
    </div>
</asp:Content>
