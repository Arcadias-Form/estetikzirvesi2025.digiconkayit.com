<%@ Page Title="" Language="C#" MasterPageFile="~/tr/tr.master" AutoEventWireup="true" CodeBehind="BasariliKayit.aspx.cs" Inherits="EstetikZirvesi_Web.tr.BasariliKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tr_Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="tr_Content" runat="server">
    <div class="row">
        <div class="col-lg-12 text-center">
            <h5 class="baslik d-none">Baþarýlý Kayýt</h5>
            <p>
                <asp:Image ID="ImgOk" runat="server" CssClass="w-50" Style="max-width: 180px;" ImageUrl="~/Gorseller/tick.png" />
            </p>
            <div style="color: white;">
                <p>
                    Sayýn
                        <asp:Label ID="lblAdSoyad" runat="server" Text=""></asp:Label>,
                </p>
                <asp:Panel ID="PnlKrediKarti" runat="server" Visible="false" CssClass="text-center">
                    <p>
                        Kaydýnýz için teþekkür ederiz.
                    </p>
                    <p>
                        E-postanýza yazýlý bir onay gönderildi.
                    </p>
                    <p>
                        Ýhtiyacýnýz olabilecek her türlü yardým için <a href="mailto:estetikzirvesi@rubikonturizm.com">estetikzirvesi@rubikonturizm.com</a> iletiþime geçebilirsiniz.
                    </p>
                </asp:Panel>

                <asp:Panel ID="PnlBankaBilgisi" runat="server" CssClass="text-center" Visible="false">
                    <p>
                        Kayýt baþvurunuz için çok teþekkür ederiz.
                    </p>
                    <p>
                        Banka havalesini gerçekleþtirmek için lütfen aþaðýda banka hesabtan ödemenizi gerçekleþtiriniz.
                    </p>
                    <p>Ödemenizi takip edebilmemiz için, dekontunuzu <a href="mailto:estetikzirvesi@rubikonturizm.com">estetikzirvesi@rubikonturizm.com</a> adresine sipariþ numarasý içerecek þekilde göndermeyi unutmayýnýz.</p>
                </asp:Panel>

                <p class="text-center">
                    <u>Sipariþ Numarasý:</u>
                    <asp:Label ID="lblOdemeID" runat="server" Font-Bold="true"></asp:Label>
                </p>
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="tr_SubContent" runat="server">
</asp:Content>
