

Ext.apply(X.ajax, {
    errorMsg: "Hata bilgisi: {0} ({1})"
});

Ext.apply(X.util, {
    alertTitle: "Uyarı",
    confirmTitle: "Onay",
    formAlertMsg: "Lütfen {0} alanı için geçerli bir değer giriniz!",
    formAlertTitle: "Hatalı form bilgisi",
    loading: "Yükleniyor..."
});

Ext.apply(X.wnd, {
    closeButtonTooltip: "Pencereyi Kapat",
    formModifiedConfirmTitle: "Kapatmak istediğinizden emin misiniz?",
    formModifiedConfirmMsg: "Mevcut sayfadaki bilgiler değiştirildi.<br/><br/>Değişiklikleri iptal et?"
});

if (Ext.ux.SimplePagingToolbar) {
    Ext.apply(Ext.ux.SimplePagingToolbar.prototype, {
        beforePageText: "Sayfa",
        afterPageText: " / {0}",
        firstText: "İlk Sayfa",
        prevText: "Önceki Sayfa",
        nextText: "Sonraki Sayfa",
        lastText: "Son Sayfa",
        displayMsg: "{0} - {1} (Toplam {2})",
        emptyMsg: 'Gösterilecek bilgi yok'
    });
}
