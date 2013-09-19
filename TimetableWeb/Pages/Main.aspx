<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TimetableWeb.Pages.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<asp:Label ID="lblMessage" runat="server" />

    <asp:Button ID="btnLogout" OnClick="btnLogout_Click" Text="Wyloguj" runat="server" />

</asp:Content>
