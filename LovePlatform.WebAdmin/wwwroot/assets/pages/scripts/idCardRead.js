function Button1_onclick() {
    var CVR_IDCard = document.getElementById("CVR_IDCard");
    var strReadResult = CVR_IDCard.ReadCard();
    console.log(strReadResult);
    if (strReadResult == "0") {
        // document.all['Name'].value = CVR_IDCard.Name;
        // document.all['Sex'].value = CVR_IDCard.Sex;
        // document.all['Nation'].value = CVR_IDCard.Nation;
        // document.all['Born'].value = CVR_IDCard.Born;
        // document.all['Address'].value = CVR_IDCard.Address;
        // document.all['CardNo'].value = CVR_IDCard.CardNo;
        // document.all['IssuedAt'].value = CVR_IDCard.IssuedAt;
        // document.all['EffectedDate'].value = CVR_IDCard.EffectedDate;
        // document.all['ExpiredDate'].value = CVR_IDCard.ExpiredDate;
        // document.all['SAMID'].value = CVR_IDCard.SAMID;
        // document.all['pic'].src = 'data:image/jpeg;base64,' + CVR_IDCard.Picture;
        // document.all['Picture'].value = CVR_IDCard.Picture;
        // document.all['PictureLen'].value = CVR_IDCard.PictureLen
        // document.all['PFMSG'].value = CVR_IDCard.PFMsg;

        return CVR_IDCard
    }
    else{
        console.log(strReadResult);
    }
}