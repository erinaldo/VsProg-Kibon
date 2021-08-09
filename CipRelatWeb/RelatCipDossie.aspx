<%@ Page Language="VB" MasterPageFile="~/CipMaster.master" AutoEventWireup="false" Inherits="CipRelatWeb.RelatCipDossie" title="Dossiê de liberação" Codebehind="RelatCipDossie.aspx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1024" style="vertical-align: top;">
        <tr>
            <td colspan="3" style="height: 28px; text-align: center" >
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Dossiê de Liberação">
                </asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: center" >
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: center" >
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Pesquisa"
                    Width="650px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Início"></asp:Label></td>
            <td style="width: 630px">
                <asp:TextBox ID="txtDataHoraIni" runat="server" Width="200px" style="text-align: center"></asp:TextBox>
                <asp:CalendarExtender ID="txtDataHoraIni_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDataHoraIni" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                &nbsp;
                (dd/mm/aaaa) &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="butRefresh" runat="server" Text="      Refresh      " Width="112px" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Fim"></asp:Label></td>
            <td style="width: 630px">
                <asp:TextBox ID="txtDataHoraFim" runat="server" Width="200px" style="text-align: center"></asp:TextBox>
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
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" 
                    Text="Circuito"></asp:Label></td>
            <td style="width: 630px">
                <asp:DropDownList ID="ddlCirc" runat="server" Width="208px" AutoPostBack="True">
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
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
                &nbsp;</td>
            <td style="width: 630px; height: 21px;">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 650px" >
        <tr>
            <td style="width: 650px">
            </td>
        </tr>
        <tr>
            <td style="width: 821px; height: 197px; vertical-align: top;">
                <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="1024px">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="CipId" HeaderText="CipId">
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RotaId" HeaderText="RotaId">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RotaDescr" HeaderText="Descrição">
                        </asp:BoundField>
                        <asp:BoundField DataField="Circ" HeaderText="Circ">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RecNum" HeaderText="RecNum" />
                        <asp:BoundField DataField="RecNome" HeaderText="Receita" />
                        <asp:BoundField DataField="RecDescr" HeaderText="Descrição" />
                        <asp:BoundField DataField="RecCodigo" HeaderText="Código" />
                        <asp:ButtonField ButtonType="Image" HeaderText="Html" ImageUrl="~/Img/report_key.png"
                            Text="Html" CommandName="Html">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Image" HeaderText="Xml" ImageUrl="~/Img/report_xls.png" CommandName="Xls">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ButtonField>
                        <asp:BoundField DataField="DataHoraIni" HeaderText="Data de In&#237;cio">
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DataHoraFim" HeaderText="Data de Fim">
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sts" HeaderText="Status">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
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

