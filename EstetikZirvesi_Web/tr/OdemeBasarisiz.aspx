<%@ Page Title="" Language="C#" MasterPageFile="~/tr/tr.master" AutoEventWireup="true" CodeBehind="OdemeBasarisiz.aspx.cs" Inherits="EstetikZirvesi_Web.tr.OdemeBasarisiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="tr_Head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="tr_Content" runat="server">
    <div class="row">
        <div class="col-lg-12 text-center">
            <fieldset style="color: red">
                <legend>Ödeme Baþarýsýz</legend>
                <p>
                    <asp:Image ID="ImgFail" runat="server" CssClass="w-50" Style="max-width: 180px;" ImageUrl="~/Gorseller/Failed.png" />
                </p>
                <p>
                    Sayýn
                    <asp:Label ID="lblAdSoyad" runat="server"></asp:Label>
                </p>
                <p>
                    Ýþlemin baþarýsýz olduðunu lütfen unutmayýn, bankalar bazen güvenlik nedeniyle kartlarý bloke ettiðinden, bir kez daha denemeden önce lütfen bankanýzla iletiþime geçerek nedenini açýklýða kavuþturun. Lütfen kredi kartýnýzý uluslararasý ödemelerde kullanacaðýnýzý ve sizin tarafýnýzdan yetkilendirildiðini bildirin.
                </p>
                <p>
                    Lütfen online ödemelere açýk olduðundan emin olunuz.
                </p>
                <p>
                    Lütfen ödeme için yeterli limitin olduðundan emin olun.
                </p>
                <p style="color: black">
                    <u>Sipariþ No:</u> <asp:Label ID="lblOdemeID" runat="server" Font-Bold="true"></asp:Label>
                </p>
            </fieldset>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="tr_SubContent" runat="server">
</asp:Content>
