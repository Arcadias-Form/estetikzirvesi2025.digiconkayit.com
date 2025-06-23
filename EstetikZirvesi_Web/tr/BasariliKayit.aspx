<%@ Page Title="" Language="C#" MasterPageFile="~/tr/tr.master" AutoEventWireup="true" CodeBehind="BasariliKayit.aspx.cs" Inherits="EstetikZirvesi_Web.tr.BasariliKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tr_Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="tr_Content" runat="server">
    <div class="row">
        <div class="col-lg-12 text-center">
            <h5 class="baslik d-none">Ba�ar�l� Kay�t</h5>
            <p>
                <asp:Image ID="ImgOk" runat="server" CssClass="w-50" Style="max-width: 180px;" ImageUrl="~/Gorseller/tick.png" />
            </p>
            <div style="color: white;">
                <p>
                    Say�n
                        <asp:Label ID="lblAdSoyad" runat="server" Text=""></asp:Label>,
                </p>
                <asp:Panel ID="PnlKrediKarti" runat="server" Visible="false" CssClass="text-center">
                    <p>
                        Kayd�n�z i�in te�ekk�r ederiz.
                    </p>
                    <p>
                        E-postan�za yaz�l� bir onay g�nderildi.
                    </p>
                    <p>
                        �htiyac�n�z olabilecek her t�rl� yard�m i�in <a href="mailto:estetikzirvesi@rubikonturizm.com">estetikzirvesi@rubikonturizm.com</a> ileti�ime ge�ebilirsiniz.
                    </p>
                </asp:Panel>

                <asp:Panel ID="PnlBankaBilgisi" runat="server" CssClass="text-center" Visible="false">
                    <p>
                        Kay�t ba�vurunuz i�in �ok te�ekk�r ederiz.
                    </p>
                    <p>
                        Banka havalesini ger�ekle�tirmek i�in l�tfen a�a��da banka hesabtan �demenizi ger�ekle�tiriniz.
                    </p>
                    <p>�demenizi takip edebilmemiz i�in, dekontunuzu <a href="mailto:estetikzirvesi@rubikonturizm.com">estetikzirvesi@rubikonturizm.com</a> adresine sipari� numaras� i�erecek �ekilde g�ndermeyi unutmay�n�z.</p>
                </asp:Panel>

                <p class="text-center">
                    <u>Sipari� Numaras�:</u>
                    <asp:Label ID="lblOdemeID" runat="server" Font-Bold="true"></asp:Label>
                </p>
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="tr_SubContent" runat="server">
</asp:Content>
