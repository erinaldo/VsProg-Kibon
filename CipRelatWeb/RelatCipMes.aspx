<%@ Page Language="VB" MasterPageFile="~/CipMaster.master" AutoEventWireup="false" Inherits="CipRelatWeb.RelatCipMes" title="Periodicidade" Codebehind="RelatCipMes.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="vertical-align: top" width="1024">
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Periodicidade"
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
            </td>
            <td style="width: 630px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Mês e Ano"></asp:Label></td>
            <td style="width: 630px">
                <asp:TextBox ID="txtDataHoraIni" runat="server" Style="text-align: center" Width="200px"></asp:TextBox>&nbsp;
                (mm/aaaa) &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="butRefresh" runat="server" Text="      Refresh      " /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="DarkBlue" 
                    Text="Circuito"></asp:Label></td>
            <td style="width: 630px">
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
            <td style="width: 630px; height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 630px; height: 21px">
            </td>
        </tr>
    </table>
    <table style="width: 700px">
        <tr>
            <td style="width: 600px; height: 197px; margin-left: 0px; clip: rect(auto auto auto 0px); vertical-align: top; text-align: left;">
                <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="1024px" Font-Size="Small">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <Columns>
                        <asp:BoundField DataField="RotaId" HeaderText="RotaId">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RotaDescr" HeaderText="Descrição" />
                        <asp:BoundField DataField="Circ" HeaderText="Circuito" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D01" HeaderText="01">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D02" HeaderText="02">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D03" HeaderText="03">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D04" HeaderText="04">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D05" HeaderText="05">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D06" HeaderText="06">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D07" HeaderText="07">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D08" HeaderText="08">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D09" HeaderText="09">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D10" HeaderText="10">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D11" HeaderText="11">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D12" HeaderText="12">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D13" HeaderText="13">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D14" HeaderText="14">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D15" HeaderText="15">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D16" HeaderText="16">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D17" HeaderText="17">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D18" HeaderText="18">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D19" HeaderText="19">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D20" HeaderText="20">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D21" HeaderText="21">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D22" HeaderText="22">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D23" HeaderText="23">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D24" HeaderText="24">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D25" HeaderText="25">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D26" HeaderText="26">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D27" HeaderText="27">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D28" HeaderText="28">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D29" HeaderText="29">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D30" HeaderText="30">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="D31" HeaderText="31">
                            <ItemStyle HorizontalAlign="Center" Width="10px" />
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

