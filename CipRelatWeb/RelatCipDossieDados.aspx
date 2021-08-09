<%@ Page Language="VB" MasterPageFile="~/CipMaster.master" AutoEventWireup="false" Inherits="CipRelatWeb.RelatCipDados" title="Dossiê de liberação - Detalhes" Codebehind="RelatCipDossieDados.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="vertical-align: top" width="650">
        <tr>
            <td colspan="3" style="height: 28px; text-align: center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" Font-Strikeout="False"
                    Font-Underline="True" ForeColor="DarkBlue" Style="text-align: center" Text="Dossiê de Liberação"
                    Width="1024px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: right">
                <asp:Button ID="butRefresh" runat="server" Text="      Refresh      " Width="104px" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 28px; text-align: center;">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Font-Strikeout="False"
                    Font-Underline="False" ForeColor="DarkBlue" Style="text-align: center" Text="Relatório de CIP"
                    Width="136px"></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCipId" runat="server" Font-Bold="True" Font-Size="Medium"
                    Font-Strikeout="False" Font-Underline="False" ForeColor="DarkBlue" Style="text-align: center"
                    Text="00000" Width="80px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 1024px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="DarkBlue" 
                    Text="Rota"></asp:Label></td>
            <td style="width: 1024px">
                <asp:TextBox ID="txtRotaId" runat="server" ReadOnly="True" Width="70px" 
                    style="text-align: center"></asp:TextBox>&nbsp;
                <asp:TextBox ID="txtRotaDescr" runat="server" ReadOnly="True" Width="550px" 
                    style="text-align: left"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtRotaCirc" runat="server" ReadOnly="True" Width="70px" 
                    style="text-align: center"></asp:TextBox>
                &nbsp;&nbsp;<asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="DarkBlue" 
                    Text="Revisão"></asp:Label>&nbsp;<asp:TextBox ID="txtLimRev" 
                    runat="server" ReadOnly="True" Width="70px" 
                    style="text-align: center">0</asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px;">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="DarkBlue" 
                    Text="Receita"></asp:Label></td>
            <td style="width: 1024px">
                <asp:TextBox ID="txtRecNum" runat="server" ReadOnly="True" Width="70px" 
                    style="text-align: center"></asp:TextBox>&nbsp;&nbsp;<asp:TextBox ID="txtRecNome" runat="server" ReadOnly="True" Width="550px" 
                    style="text-align: left"></asp:TextBox>
                &nbsp;
                <asp:TextBox ID="txtRecCodigo" runat="server" ReadOnly="True" Width="218px" 
                    style="text-align: center"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Descrição"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:TextBox ID="txtRecDescr" runat="server" ReadOnly="True" Width="870px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Início"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:TextBox ID="txtDataIni" runat="server" ReadOnly="True" Width="240px" style="text-align: center"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Fim"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:TextBox ID="txtDataFim" runat="server" ReadOnly="True" Width="240px" style="text-align: center"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Operador"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:TextBox ID="txtUserNome" runat="server" ReadOnly="True" Width="240px" style="text-align: center"></asp:TextBox>
                <asp:TextBox ID="txtUserId" runat="server" ReadOnly="True" Width="40px" 
                    style="text-align: center" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Validação"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:TextBox ID="txtUserNomeValid" runat="server" ReadOnly="True" Style="text-align: center"
                    Width="240px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Cancelado"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:CheckBox ID="chkSts" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Atrasado"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
                <asp:CheckBox ID="chkFlagAtrasado" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 1024px; height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px; height: 15px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Fases do CIP"></asp:Label></td>
            <td style="width: 1024px; height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px">
                <asp:GridView ID="gvTempos" runat="server" AutoGenerateColumns="False" Width="1024px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="BlkNum" HeaderText="BlkNum" />
                        <asp:BoundField DataField="BlkDescr" HeaderText="Descrição" />
                        <asp:BoundField DataField="DataHoraIni" HeaderText="In&#237;cio" ApplyFormatInEditMode="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Duracao" HeaderText="Dura&#231;&#227;o">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Prog" HeaderText="Prog">
                            <ItemStyle HorizontalAlign="Center" />
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
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Anormalidades"></asp:Label></td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px">
                <asp:GridView ID="gvAnorm" runat="server" AutoGenerateColumns="False" Width="1024px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="DataHora" HeaderText="Data e Hora">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Mensagem" HeaderText="Mensagem" />
                        <asp:BoundField DataField="Obs" HeaderText="Obs" />
                        <asp:BoundField DataField="BlkNum" HeaderText="BlkNum" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BlkDescr" HeaderText="Descrição" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
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
            <td style="width: 100px; height: 21px">
            </td>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Pontos Críticos"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px">
                <asp:GridView ID="gvPtoCr" runat="server" AutoGenerateColumns="False" Width="1024px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3">
                    <Columns>
                        <asp:BoundField DataField="Pergunta" HeaderText="Pergunta">
                            <ItemStyle Width="700px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Resposta" HeaderText="Resposta">
                            <ItemStyle HorizontalAlign="Center" />
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
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
                <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Gráficos"></asp:Label></td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px">
                <%  =MontaGrafTemp()%>
                &nbsp;
            </td>
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
                <%  '-- Grafico de concentração --%>
                <%  =MontaGrafCond()%>
            </td>
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
                <%  '-- Grafico de vazao --%>
                <%  =MontaGrafVazao()%>
            </td>
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
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 21px">
                <%  '-- Grafico dos passos --%>
                <%  = MontaGrafBlkNum()%>
            </td>
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
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 640px; height: 21px">
            </td>
        </tr>
    </table>
</asp:Content>

