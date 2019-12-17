<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MainSite.Master" AutoEventWireup="true" CodeBehind="rEstudianteMateria.aspx.cs" Inherits="Estudiantes.UI.Registros.rEstudianteMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div id="registroEstudiante">
		<asp:Label  runat="server" Text="ID"></asp:Label>
		<asp:TextBox runat="server" ID="textboxIdEstudiante"></asp:TextBox>
		<asp:Label  runat="server" Text="Nombre Estudiante"></asp:Label>
		<asp:TextBox runat="server" ID="textboxNombreEstudiante"></asp:TextBox>

		<asp:Button runat="server" Text="Nuevo" ID="BotonNuevoEstudiante"/>
		<asp:Button runat="server" Text="Guardar" ID="BotonGuardarEstudiante"/>
		<asp:Button runat="server" Text="Eliminar" ID="BotonEliminarEstudiante"/>
	</div>
	<hr />
	<br />
	<div id="registroMateria">
		<asp:Label  runat="server" Text="ID"></asp:Label>
		<asp:TextBox runat="server" ID="textboxIdMateria"></asp:TextBox>
		<asp:Label  runat="server" Text="Nombre Materia"></asp:Label>
		<asp:TextBox runat="server" ID="textboxNombreMateria"></asp:TextBox>

		<asp:Button runat="server" Text="Nuevo" ID="BotonNuevaMateria"/>
		<asp:Button runat="server" Text="Guardar" ID="BotonGuardarMateria"/>
		<asp:Button runat="server" Text="Eliminar" ID="BotonEliminarMateria"/>
	</div>








	<style>
		#registroEstudiante, #registroMateria {
			border: dotted;
			border-radius: 3px 4px;
			border-color: black;
			padding: 10px 10px 10px 10px;
			font-size: 14px;			
		}
	</style>
</asp:Content>
