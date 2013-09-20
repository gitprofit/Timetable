<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="TimetableWeb.Controls.Navigation" %>

<nav runat="server" >

	<!--
	<asp:Menu ID="__menuTopLevel" StaticDisplayLevels="2" runat="server" >

		<Items>
			<asp:MenuItem Text="Główny" Value="Main" />
			<asp:MenuItem Text="Plany" Value="Main" />
			<asp:MenuItem Text="Przedmioty" Value="Main" />
			<asp:MenuItem Text="Prowadzący" Value="Main" />
		</Items>
		
	</asp:Menu>
	-->

	<ul id="menuTopLevel" class="menuLevel1" runat="server">
		<li>
			<a href="#">Główny</a>
		</li>
		<li>
			<a href="#">Plany</a>
			<ul id="menuSchedules" class="menuLevel2" runat="server">
				<!-- database content -->
			</ul>
		</li>
		<li>
			<a href="#">Przedmioty</a>
			<ul id="menuCourses" class="menuLevel2" runat="server">
				<!-- database content -->
			</ul>
		</li>
		<li>
			<a href="#">Prowadzący</a>
			<ul id="menuInstructors" class="menuLevel2" runat="server">
				<!-- database content -->
			</ul>
		</li>
	</ul>

</nav>