<%@ Page Title="" Language="C#" MasterPageFile="~/tr/tr.master" AutoEventWireup="true" CodeBehind="Odeme.aspx.cs" Inherits="EstetikZirvesi_Web.tr.Odeme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tr_Head" runat="server">
    <script src="<%=ResolveClientUrl("~/js/jquery.inputmask.min.js") %>"></script>
    <script>
        $(() => {
            $('#<%= txtKrediKartNo.ClientID%>').inputmask("9999 9999 9999 9999", { onincomplete: () => { $('#<%= txtKrediKartNo.ClientID%>').val(''); } });
        $('#<%= txtAy.ClientID%>').inputmask("99", { onincomplete: () => { $('#<%= txtAy.ClientID%>').val(''); } });
        $('#<%= txtYil.ClientID%>').inputmask("99", { onincomplete: () => { $('#<%= txtYil.ClientID%>').val(''); } });
        $('#<%= txtCVV2.ClientID%>').inputmask("999", { onincomplete: () => { $('#<%= txtCVV2.ClientID%>').val(''); } });
    });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="tr_Content" runat="server">
    <div class="row">
        <div class="col-md-7 mx-auto">
            <fieldset>
                <legend>Payment Information</legend>
                <table class="AlseinTable">
                    <tr>
                        <td>*</td>
                        <td>Kat�l�mc�</td>
                        <td>
                            <asp:Label ID="lblAdSoyad" runat="server" CssClass="form-control"></asp:Label>
                            <asp:HiddenField ID="hfePosta" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>�cret</td>
                        <td>
                            <asp:Label ID="lblDovizUcret" runat="server" CssClass="form-control"></asp:Label>
                            <asp:HiddenField ID="hfDovizUcret" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Sipari� Numaras�</td>
                        <td>
                            <asp:Label ID="lblOdemeID" runat="server" CssClass="form-control"></asp:Label>
                            <asp:HiddenField ID="hfOdemeID" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>*</td>
                        <td>Kredi Kart�n Ait Oldu�u �lke</td>
                        <td>
                            <asp:DropDownList ID="ddlKrediKartiUlke" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Se�iniz" Value=""></asp:ListItem>
                                <asp:ListItem Text="T�rkiye / China" Value="true"></asp:ListItem>
                                <asp:ListItem Text="Di�er" Value="false"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Kredi Kart Numaras�</td>
                        <td>
                            <asp:TextBox ID="txtKrediKartNo" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Son Kullan�m Tarihi( Ay )</td>
                        <td>
                            <asp:TextBox ID="txtAy" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Son Kullan�m Tarihi ( Y�l )</td>
                        <td>
                            <asp:TextBox ID="txtYil" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>CVV2</td>
                        <td>
                            <asp:TextBox ID="txtCVV2" runat="server" CssClass="form-control" placeholder="Kart�n�z�n arkas�nda ki 3 haneyi giriniz "></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <p align="center">
                    <asp:LinkButton ID="lnkbtnKayitOl" runat="server" CssClass="btn btn-block btn-success mt-3 mb-3" OnClick="lnkbtnKayitOl_Click" OnClientClick="$(this).css('display', 'none');"><i class="fa fa-plus"></i>&nbsp;�demeyi tamamla</asp:LinkButton>
                </p>
            </fieldset>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="tr_SubContent" runat="server">
</asp:Content>
