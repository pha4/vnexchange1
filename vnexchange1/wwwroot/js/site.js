// Write your Javascript code.
var Item = function (itemID, itemType, itemOwner, itemEmail) {
    this.ItemID = itemID;
    this.ItemType = itemType;
    this.ItemOwner = itemOwner;
    this.ItemEmail = itemEmail;
};
var GlobalConstant = new Object();
GlobalConstant.HideItemActionURL = "";
GlobalConstant.CloseItemActionURL = "";
GlobalConstant.ShowItemActionURL = "";
GlobalConstant.ApproveItemActionURL = "";
GlobalConstant.CreateRequestItemActionURL = "";

function GetRequestTypeText(requestType) {
    if (requestType == "doi")
    {
        return "đổi";
    }
};

Item.prototype = {    
    initRequest: function (requestType) {
        switch (requestType) {
            case "mua":
            case "doi":
            case "xin":
                var requestTypeText = GetRequestTypeText(requestType);
                $('#myModalMua').modal('show');
                $("#myModalMuaUser").text(this.ItemOwner);
                $("#btnGuiTinNhan").attr("onclick", "Item[" + this.ItemID + "].request('" + requestType ==  + "');");
                $("#lblRequestType").text(requestTypeText);
                break;            
            default:
                return false;

        }
    },
    request: function (requestType) {
        $.ajax({
            url: GlobalConstant.CreateRequestItemActionURL,
            type: "POST",
            data: {
                itemID: this.ItemID,
                requestType: requestType,
                message: $("#txtMessage").val()
            },
            datatype: 'json',
            ContentType: 'application/json;utf-8'
        }).done(function (resp) {
            if (resp === true) {

                $('#myModalMua').modal('hide');

                //$("#item_" + this.ItemID).hide();
                //window.location.href = window.location.href;
            }
            //window.location.href = "/items/all";
        }).error(function (err) {
            alert("Error " + err.status);
        });
        return false;
    },

    hide: function () {

        $.ajax({
            url: GlobalConstant.HideItemActionURL,
            type: "POST",
            data: {
                itemID: this.ItemID,
            },
            datatype: 'json',
            ContentType: 'application/json;utf-8'
        }).done(function (resp) {
            if (resp === true) {
                //$("#item_" + this.ItemID).hide();
                window.location.href = window.location.href;
            }
            //window.location.href = "/items/all";
        }).error(function (err) {
            alert("Error " + err.status);
        });
        return false;

    },
    show: function () {

        $.ajax({
            url: GlobalConstant.ShowItemActionURL,
            type: "POST",
            data: {
                itemID: this.ItemID,
            },
            datatype: 'json',
            ContentType: 'application/json;utf-8'
        }).done(function (resp) {
            if (resp === true) {
                //$("#item_" + this.ItemID).hide();
                window.location.href = window.location.href;
            }
            //window.location.href = "/items/all";
        }).error(function (err) {
            alert("Error " + err.status);
        });
        return false;

    },
    edit: function () { },

    close: function () {
        $.ajax({
            url: GlobalConstant.CloseItemActionURL,
            type: "POST",
            data: {
                itemID: this.ItemID,
            },
            datatype: 'json',
            ContentType: 'application/json;utf-8'
        }).done(function (resp) {
            if (resp === true) {
                //$("#item_" + this.ItemID).hide();
                window.location.href = window.location.href;
            }
            //window.location.href = "/items/all";
        }).error(function (err) {
            alert("Error " + err.status);
        });
        return false;
    },

    approve: function () {
        $.ajax({
            url: GlobalConstant.ApproveItemActionURL,
            type: "POST",
            data: {
                itemID: this.ItemID,
            },
            datatype: 'json',
            ContentType: 'application/json;utf-8'
        }).done(function (resp) {
            if (resp === true) {
                //$("#item_" + this.ItemID).hide();
                window.location.href = window.location.href;
            }
            //window.location.href = "/items/all";
        }).error(function (err) {
            alert("Error " + err.status);
        });
        return false;
    }
};