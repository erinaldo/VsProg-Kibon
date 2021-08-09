<%@ Page Language="VB" MasterPageFile="~/CipMaster.master" AutoEventWireup="false" Inherits="CipRelatWeb.RelatCipAnorm" title="Anormalidades" Codebehind="RelatCipAnorm.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="vertical-align: top" width="1024">
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Anormalidades"
                    Width="1024px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="text-align: center;" colspan="3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Pesquisa"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Início"></asp:Label></td>
            <td style="width: 640px">
                <asp:TextBox ID="txtDataHoraIni" runat="server" Style="text-align: center" Width="200px"></asp:TextBox>
                <asp:CalendarExtender ID="txtDataHoraIni_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDataHoraIni" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                &nbsp;
                (dd/mm/aaaa) &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="butRefresh" runat="server" Text="      Refresh      " /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Fim"></asp:Label></td>
            <td style="width: 640px">
                <asp:TextBox ID="txtDataHoraFim" runat="server" Style="text-align: center" Width="200px"></asp:TextBox>
                <asp:CalendarExtender ID="txtDataHoraFim_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDataHoraFim" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                &nbsp;
                (dd/mm/aaaa)</td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" 
                    Text="Circuito"></asp:Label></td>
            <td style="width: 640px">
                <asp:DropDownList ID="ddlCirc" runat="server" AutoPostBack="True" Width="208px">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>D</asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>CA</asp:ListItem>
                    <asp:ListItem>CB</asp:ListItem>
                    <asp:ListItem>CC</asp:ListItem>
                    <asp:ListItem>CD</asp:ListItem>
                    <asp:ListItem>CE</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
                &nbsp;</td>
            <td style="width: 640px; height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px">
                <asp:GridView ID="gvAnorm" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="1024px">
                    <Columns>
                        <asp:BoundField DataField="DataHora" HeaderText="Data e Hora" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Mensagem" HeaderText="Mensagem" ReadOnly="True" />
                        <asp:BoundField DataField="Obs" HeaderText="Obs" ReadOnly="True" />
                        <asp:BoundField DataField="BlkNum" HeaderText="BlkNum" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

