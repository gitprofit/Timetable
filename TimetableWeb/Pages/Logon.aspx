<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="TimetableWeb.Pages.Logon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


	<table>

		<tr>
			<td>Login:</td>
			<td>
				<asp:TextBox ID="txtUsername" runat="server" />
			</td>
			<td>
				<asp:RequiredFieldValidator ID="valUsername"
					ControlToValidate="txtUsername"
					Display="Dynamic"
					ErrorMessage="Pole wymagane."
					runat="server" />
			</td>
		</tr>

		<tr>
			<td>Hasło:</td>
			<td>
				<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
			</td>
			<td>
				<asp:RequiredFieldValidator ID="valPassword"
					ControlToValidate="txtPassword"
					ErrorMessage="Pole wymagane."
					ForeColor="Red"
					runat="server" />
			</td>
		</tr>

		<tr>
			<td>Pamiętaj mnie</td>
			<td>
				<asp:CheckBox ID="chkPersist" runat="server" />
			</td>
		</tr>

	</table>

	<asp:Button ID="btnLogon" OnClick="btnLogon_Click" Text="Zaloguj" runat="server" />


</asp:Content>
