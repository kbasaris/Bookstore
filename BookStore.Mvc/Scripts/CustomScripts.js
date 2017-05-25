$(function () {
    var fr = new FileReader();
    $("#file").on("change", function () {
        var files = $("#file")[0].files;
        if (FileReader && files && files.length) {
            fr.readAsArrayBuffer(files[0]);
            console.log(files);
            console.log(files[0]);
            fr.onload = function () {
                var base64 = '';
                var base64WithPrefix = '';
                console.log(fr.result);
                var imageData = new Uint8Array(fr.result);
                base64 = btoa(Uint8ToString(imageData));
                base64WithPrefix = "data:image/jpeg;base64," + base64
                //alert(binary);
                $("#imgBase64").prop("src", base64WithPrefix)
                $("#ImageBase64").val(base64);
                $("#ImageName").val(files[0].name);
            };
        }
    });

    function Uint8ToString(u8a) {
        var CHUNK_SZ = 0x8000;
        var c = [];
        for (var i = 0; i < u8a.length; i += CHUNK_SZ) {
            c.push(String.fromCharCode.apply(null, u8a.subarray(i, i + CHUNK_SZ)));
        }
        return c.join("");
    }


    $('#btnRemoveCart').click(function () {
        alert('onclick');
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");

        if (recordToDelete !== '') {
            console.log('onclick');
            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart", { "cartItemId": recordToDelete },
                function (data) {
                    // Successful requests get here
                });
        }
    });

        $("#shoppingcart p").html("Cart("+getCookie("cart")+")");
    
        $("#btnSignOut").on("click", function () {
            var creds = readCookie("creds");
            var accessToken = creds.split("accessToken=");
            //console.log(accessToken[1]);

            $.ajax({
                url: "http://localhost:6478/api/Account/Logout",
                type: "POST",
                headers: { "Access-Control-Allow-Origin": "*", "Authorization": "Bearer " + accessToken[1]},
                success: function (result) {
                    eraseCookie("creds");
                    window.location.href = "/Account/Login"
                },
                error: function (result) {
                   // console.log(result);
                }
            })

        });

        function delete_cookie(name) {
            document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        }

        function readCookie(name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) === ' ') c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
            }
            return null;
        }
        function eraseCookie(name) {
            createCookie(name, "", -1);
        }
        function createCookie(name, value, days) {
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                var expires = "; expires=" + date.toGMTString();
            }
            else var expires = "";
            document.cookie = name + "=" + value + expires + "; path=/";
        }


    function getCookie(cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) === ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) === 0) {
               var cookie = c.substring(name.length, c.length);
               return cookie.substring(10, cookie.length)
            }
        }
        return "";
    }
});
