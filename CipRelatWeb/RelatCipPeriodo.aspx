<%@ Page Language="VB" MasterPageFile="~/CipMaster.master" AutoEventWireup="false" Inherits="CipRelatWeb.RelatCipPeriodo" title="Período" Codebehind="RelatCipPeriodo.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="vertical-align: top" width="650">
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Período"
                    Width="1024px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Pesquisa"
                    Width="1024px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Início"></asp:Label></td>
            <td style="width: 630px">
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
            <td style="width: 630px">
                <asp:TextBox ID="txtDataHoraFim" runat="server" Style="text-align: center" Width="200px"></asp:TextBox>
                <asp:CalendarExtender ID="txtDataHoraFim_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDataHoraFim" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                &nbsp;
                (dd/mm/aaaa) &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 630px">
            </td>
        </tr>
    </table>
    <table style="width: 1024px">
        <tr>
            <td style="width: 1024px; vertical-align: top;">
                <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="1024px">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="CipId" HeaderText="CipId">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RotaId" HeaderText="RotaId">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RotaDescr" HeaderText="Descrição">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Circ" HeaderText="Circ" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RecNum" HeaderText="RecNum" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RecNome" HeaderText="Receita" />
                        <asp:BoundField DataField="RecDescr" HeaderText="Descrição" />
                        <asp:BoundField DataField="RecCodigo" HeaderText="Código" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataHoraIni" HeaderText="Data de In&#237;cio">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataHoraFim" HeaderText="Data de Fim">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OperIni" HeaderText="Oper. In&#237;cio">
                        </asp:BoundField>
                        <asp:BoundField DataField="OperFim" HeaderText="Oper. Valid." />
                        <asp:CheckBoxField DataField="Sts" HeaderText="Sts" />
                        <asp:CheckBoxField DataField="FlagAtrasado" HeaderText="Atr." />
                    </Columns>
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

