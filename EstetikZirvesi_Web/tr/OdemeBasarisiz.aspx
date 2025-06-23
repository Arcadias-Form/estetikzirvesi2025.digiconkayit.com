<%@ Page Title="" Language="C#" MasterPageFile="~/tr/tr.master" AutoEventWireup="true" CodeBehind="OdemeBasarisiz.aspx.cs" Inherits="EstetikZirvesi_Web.tr.OdemeBasarisiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tr_Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="tr_Content" runat="server">
    <div class="row">
        <div class="col-lg-12 text-center">
            <fieldset style="color: red">
                <legend>�deme Ba�ar�s�z</legend>
                <p>
                    <asp:Image ID="ImgFail" runat="server" CssClass="w-50" Style="max-width: 180px;" ImageUrl="~/Gorseller/Failed.png" />
                </p>
                <p>
                    Say�n
                    <asp:Label ID="lblAdSoyad" runat="server"></asp:Label>
                </p>
                <p>
                    ��lemin ba�ar�s�z oldu�unu l�tfen unutmay�n, bankalar bazen g�venlik nedeniyle kartlar� bloke etti�inden, bir kez daha denemeden �nce l�tfen bankan�zla ileti�ime ge�erek nedenini a��kl��a kavu�turun. L�tfen kredi kart�n�z� uluslararas� �demelerde kullanaca��n�z� ve sizin taraf�n�zdan yetkilendirildi�ini bildirin.
                </p>
                <p>
                    L�tfen online �demelere a��k oldu�undan emin olunuz.
                </p>
                <p>
                    L�tfen �deme i�in yeterli limitin oldu�undan emin olun.
                </p>
                <p style="color: black">
                    <u>Sipari� No:</u> <asp:Label ID="lblOdemeID" runat="server" Font-Bold="true"></asp:Label>
                </p>
            </fieldset>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="tr_SubContent" runat="server">
</asp:Content>
